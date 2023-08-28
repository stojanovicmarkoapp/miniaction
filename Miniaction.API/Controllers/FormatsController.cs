using Microsoft.AspNetCore.Mvc;
using Miniaction.Application.UseCaseHandling;
using Miniaction.Application.UseCases.Queries.Searches;
using Miniaction.Application.UseCases.Queries;
using Miniaction.DataAccess;
using Miniaction.Application.UseCases.Commands;
using Miniaction.Application.UseCases.DTO;
using Miniaction.Implementation.Validators;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Miniaction.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormatsController : ControllerBase
    {
        private MiniactionContext _context;
        private IQueryHandler _queryHandler;
        public FormatsController(MiniactionContext context,
                                  IQueryHandler queryHandler)
        {
            _context = context;
            _queryHandler = queryHandler;
        }
        // GET: api/<FormatsController>
        [HttpGet]
        [Authorize]
        public IActionResult Get([FromQuery] FormatSearch search,
                                 [FromServices] ISearchFormatsQuery query)
        {
            return Ok(_queryHandler.HandleQuery(query, search));
        }

        // GET api/<FormatsController>/5
        [HttpGet("{id}")]
        [Authorize]
        public IActionResult Get(int id,
                          [FromServices] IFindFormatQuery query)
        {
            return Ok(_queryHandler.HandleQuery(query, id));
        }

        // POST api/<FormatsController>
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] CreateFormatDTO dto,
                                 [FromServices] ICreateFormatCommand command)
        {
            command.Execute(dto);
            return StatusCode(201);
        }

        // PATCH api/<FormatsController>/5
        [HttpPatch("{id}")]
        public IActionResult Patch(int id,
                                [FromBody] PatchFormatDTO dto,
                                [FromServices] PatchFormatValidator validator)
        {
            var format = _context.Formats.FirstOrDefault(f => f.ID == id);
            if (format == null)
            {
                return NotFound();
            }
            var result = validator.Validate(dto);
            if (!result.IsValid)
            {
                return UnprocessableEntity();
            }
            if (!string.IsNullOrEmpty(dto.Name))
            {
                format.Name = dto.Name;
            }
            _context.SaveChanges();
            return NoContent();
        }

        // DELETE api/<FormatsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var format = _context.Formats.FirstOrDefault(f=>f.ID==id);
            if (format == null)
            {
                return NotFound();
            }
            _context.Formats.Remove(format);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
