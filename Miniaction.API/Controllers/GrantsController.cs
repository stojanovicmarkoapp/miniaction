using Microsoft.AspNetCore.Mvc;
using Miniaction.Application.UseCaseHandling;
using Miniaction.Application.UseCases.Commands;
using Miniaction.Application.UseCases.DTO;
using Miniaction.Application.UseCases.Queries.Searches;
using Miniaction.Application.UseCases.Queries;
using Miniaction.DataAccess;
using Miniaction.Implementation.Validators;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using Miniaction.Domain.Entities;

namespace Miniaction.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GrantsController : ControllerBase
    {
        private MiniactionContext _context;
        private IQueryHandler _queryHandler;
        public GrantsController(MiniactionContext context,
                                  IQueryHandler queryHandler)
        {
            _context = context;
            _queryHandler = queryHandler;
        }
        // GET: api/<GrantsController>
        [HttpGet]
        [Authorize]
        public IActionResult Get([FromQuery] GrantSearch search,
                                 [FromServices] ISearchGrantsQuery query)
        {
            return Ok(_queryHandler.HandleQuery(query, search));
        }

        // GET api/<GrantsController>/5
        [HttpGet("{id}")]
        [Authorize]
        public IActionResult Get(int id,
                          [FromServices] IFindGrantQuery query)
        {
            return Ok(_queryHandler.HandleQuery(query, id));
        }

        // POST api/<GrantsController>
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] CreateGrantDTO dto,
                                 [FromServices] ICreateGrantCommand command)
        {
            command.Execute(dto);
            return StatusCode(201);
        }

        // DELETE api/<GrantsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int roleID, int useCaseID)
        {
            var grant = _context.Grants.FirstOrDefault(g => g.UseCaseID == useCaseID && g.RoleID == roleID);
            if (grant == null)
            {
                return NotFound();
            }
            _context.Grants.Remove(grant);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
