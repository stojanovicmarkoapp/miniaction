using Microsoft.AspNetCore.Mvc;
using Miniaction.Application.UseCaseHandling;
using Miniaction.Application.UseCases.Queries.Searches;
using Miniaction.Application.UseCases.Queries;
using Miniaction.DataAccess;
using Miniaction.Application.UseCases.Commands;
using Miniaction.Application.UseCases.DTO;
using Miniaction.Implementation.Validators;
using System.Linq;
using Miniaction.Domain.Entities;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Miniaction.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StarsController : ControllerBase
    {
        private MiniactionContext _context;
        private IQueryHandler _queryHandler;
        public StarsController(MiniactionContext context,
                                  IQueryHandler queryHandler)
        {
            _context = context;
            _queryHandler = queryHandler;
        }
        // GET: api/<StarsController>
        [HttpGet]
        [Authorize]
        public IActionResult Get([FromQuery] StarSearch search,
                                 [FromServices] ISearchStarsQuery query)
        {
            return Ok(_queryHandler.HandleQuery(query, search));
        }

        // GET api/<StarsController>/5
        [HttpGet("{id}")]
        [Authorize]
        public IActionResult Get(int id,
                          [FromServices] IFindStarQuery query)
        {
            return Ok(_queryHandler.HandleQuery(query, id));
        }

        // POST api/<StarsController>
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] CreateStarDTO dto,
                                 [FromServices] ICreateStarCommand command)
        {
            command.Execute(dto);
            return StatusCode(201);
        }

        // PATCH api/<StarsController>/5
        [HttpPatch("{id}")]
        public IActionResult Patch(int id,
                                [FromBody] PatchStarDTO dto,
                                [FromServices] PatchStarValidator validator)
        {
            var star = _context.Stars.FirstOrDefault(s => s.ID == id);
            if (star == null)
            {
                return NotFound();
            }
            var result = validator.Validate(dto);
            if (!result.IsValid)
            {
                return UnprocessableEntity();
            }
            if (dto.Score.HasValue)
            {
                star.Score = (int)dto.Score;
            }
            if (!string.IsNullOrEmpty(dto.Description))
            {
                star.Description = dto.Description;
            }
            _context.SaveChanges();
            return NoContent();
        }

        // DELETE api/<StarsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var star = _context.Stars.FirstOrDefault(s=>s.ID==id);
            if (star == null)
            {
                return NotFound();
            }
            _context.Stars.Remove(star);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
