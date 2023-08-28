using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Miniaction.Application.UseCaseHandling;
using Miniaction.Application.UseCases.Commands;
using Miniaction.Application.UseCases.DTO;
using Miniaction.Application.UseCases.Queries;
using Miniaction.Application.UseCases.Queries.Searches;
using Miniaction.DataAccess;
using Miniaction.Implementation.Validators;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Miniaction.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SerialsController : ControllerBase
    {
        private MiniactionContext _context;
        private IQueryHandler _queryHandler;
        public SerialsController(MiniactionContext context,
                                  IQueryHandler queryHandler)
        {
            _context = context;
            _queryHandler = queryHandler;
        }
        // GET: api/<SerialsController>
        [HttpGet]
        [Authorize]
        public IActionResult Get([FromQuery] SerialSearch search,
                                 [FromServices] ISearchSerialsQuery query)
        {
            return Ok(_queryHandler.HandleQuery(query, search));
        }

        // GET api/<SerialsController>/5
        [HttpGet("{id}")]
        [Authorize]
        public IActionResult Get(int id,
                                 [FromServices] IFindSerialQuery query)
        {
            return Ok(_queryHandler.HandleQuery(query, id));
        }

        // POST api/<SerialsController>
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] CreateSerialDTO dto,
                                  [FromServices] ICreateSerialCommand command)
        {
            command.Execute(dto);
            return StatusCode(201);
        }

        // PATCH api/<SerialsController>/5
        [HttpPatch("{id}")]
        public IActionResult Patch(int id,
                                [FromBody] PatchSerialDTO dto,
                                [FromServices] PatchSerialValidator validator)
        {
            var serial = _context.Serials.FirstOrDefault(s => s.ID == id);
            if (serial == null)
            {
                return NotFound();
            }
            var result = validator.Validate(dto);
            if (!result.IsValid)
            {
                return UnprocessableEntity();
            }
            if (!string.IsNullOrEmpty(dto.Title))
            {
                serial.Title = dto.Title;
            }
            if (!string.IsNullOrEmpty(dto.Features))
            {
                serial.Features = dto.Features;
            }
            if (dto.Released.HasValue)
            {
                serial.Released = (int)dto.Released;
            }
            if (dto.PGID.HasValue)
            {
                serial.PGID = (int)dto.PGID;
            }
            if (dto.GenreID.HasValue)
            {
                serial.GenreID = (int)dto.GenreID;
            }
            if (dto.NetworkID.HasValue)
            {
                serial.NetworkID = (int)dto.NetworkID;
            }
            _context.SaveChanges();
            return NoContent();
        }

        // DELETE api/<SerialsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var serial = _context.Serials.FirstOrDefault(s=>s.ID==id);
            if (serial == null)
            {
                return NotFound();
            }
            _context.Serials.Remove(serial);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
