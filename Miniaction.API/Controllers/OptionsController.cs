using Microsoft.AspNetCore.Mvc;
using Miniaction.Application.UseCaseHandling;
using Miniaction.Application.UseCases.Commands;
using Miniaction.Application.UseCases.DTO;
using Miniaction.Application.UseCases.Queries.Searches;
using Miniaction.Application.UseCases.Queries;
using Miniaction.DataAccess;
using Miniaction.Implementation.Validators;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Miniaction.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OptionsController : ControllerBase
    {
        private MiniactionContext _context;
        private IQueryHandler _queryHandler;
        public OptionsController(MiniactionContext context,
                                  IQueryHandler queryHandler)
        {
            _context = context;
            _queryHandler = queryHandler;
        }
        // GET: api/<OptionsController>
        [HttpGet]
        [Authorize]
        public IActionResult Get([FromQuery] OptionSearch search,
                                 [FromServices] ISearchOptionsQuery query)
        {
            return Ok(_queryHandler.HandleQuery(query, search));
        }

        // GET api/<OptionsController>/5
        [HttpGet("{id}")]
        [Authorize]
        public IActionResult Get(int id,
                                 [FromServices] IFindOptionQuery query)
        {
            return Ok(_queryHandler.HandleQuery(query, id));
        }

        // POST api/<OptionsController>
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] CreateOptionDTO dto,
                                  [FromServices] ICreateOptionCommand command)
        {
            command.Execute(dto);
            return StatusCode(201);
        }

        // PATCH api/<OptionsController>/5
        [HttpPatch("{id}")]
        public IActionResult Patch(int id,
                                [FromBody] PatchOptionDTO dto,
                                [FromServices] PatchOptionValidator validator)
        {
            var option = _context.Options.FirstOrDefault(o => o.ID == id);
            if (option == null)
            {
                return NotFound();
            }
            var result = validator.Validate(dto);
            if (!result.IsValid)
            {
                return UnprocessableEntity();
            }
            if (dto.Available.HasValue)
            {
                option.Available = (bool)dto.Available;
            }
            if (dto.Price.HasValue)
            {
                option.Price = (decimal)dto.Price;
            }
            _context.SaveChanges();
            return NoContent();
        }

        // DELETE api/<OptionsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var option = _context.Options.FirstOrDefault(o=>o.ID==id);
            if (option == null)
            {
                return NotFound();
            }
            _context.Options.Remove(option);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
