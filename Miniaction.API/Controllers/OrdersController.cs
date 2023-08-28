using Microsoft.AspNetCore.Mvc;
using Miniaction.Application.UseCaseHandling;
using Miniaction.Application.UseCases.Commands;
using Miniaction.Application.UseCases.DTO;
using Miniaction.Application.UseCases.Queries.Searches;
using Miniaction.Application.UseCases.Queries;
using Miniaction.DataAccess;
using Miniaction.Implementation.Validators;
using System.Linq;
using Miniaction.Domain.Entities;
using System;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Miniaction.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private MiniactionContext _context;
        private IQueryHandler _queryHandler;
        public OrdersController(MiniactionContext context,
                                  IQueryHandler queryHandler)
        {
            _context = context;
            _queryHandler = queryHandler;
        }
        // GET: api/<OrdersController>
        [HttpGet]
        [Authorize]
        public IActionResult Get([FromQuery] OrderSearch search,
                                 [FromServices] ISearchOrdersQuery query)
        {
            return Ok(_queryHandler.HandleQuery(query, search));
        }

        // GET api/<OrdersController>/5
        [HttpGet("{id}")]
        [Authorize]
        public IActionResult Get(int id,
                                 [FromServices] IFindOrderQuery query)
        {
            return Ok(_queryHandler.HandleQuery(query, id));
        }

        // POST api/<OrdersController>
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] CreateOrderDTO dto,
                                  [FromServices] ICreateOrderCommand command)
        {
            command.Execute(dto);
            return StatusCode(201);
        }

        // PATCH api/<OrdersController>/5
        [HttpPatch("{id}")]
        public IActionResult Patch(int id,
                                [FromBody] PatchOrderDTO dto,
                                [FromServices] PatchOrderValidator validator)
        {
            var order = _context.Orders.FirstOrDefault(o => o.ID == id);
            if (order == null)
            {
                return NotFound();
            }
            var result = validator.Validate(dto);
            if (!result.IsValid)
            {
                return UnprocessableEntity();
            }
            if(dto.Paid == true)
            {
                if (!dto.PaidAt.HasValue && !order.PaidAt.HasValue)
                {
                    throw new Exception("If order is paid, you have to provide pay time if not already in database!");
                }
            }
            else
            {
                if (dto.PaidAt.HasValue)
                {
                    throw new Exception("You have to mark order as paid to be able to provide its pay time!");
                }
            }
            if (dto.PaidAt.HasValue)
            {
                order.PaidAt = (DateTime)dto.PaidAt;
            }
            order.Paid = (bool)dto.Paid;
            if (dto.Quantity.HasValue)
            {
                order.Quantity = (int)dto.Quantity;
            }
            if (dto.Price.HasValue)
            {
                order.Price = (decimal)dto.Price;
            }
            _context.SaveChanges();
            return NoContent();
        }

        // DELETE api/<OrdersController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var order = _context.Orders.FirstOrDefault(o=>o.ID==id);
            if (order == null)
            {
                return NotFound();
            }
            _context.Orders.Remove(order);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
