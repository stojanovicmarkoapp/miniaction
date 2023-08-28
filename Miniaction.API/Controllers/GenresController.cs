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
    public class GenresController : ControllerBase
    {
        private MiniactionContext _context;
        private IQueryHandler _queryHandler;
        public GenresController(MiniactionContext context,
                                  IQueryHandler queryHandler)
        {
            _context = context;
            _queryHandler = queryHandler;
        }
        // GET: api/<GenresController>
        [HttpGet]
        [Authorize]
        public IActionResult Get([FromQuery] GenreSearch search,
                                 [FromServices] ISearchGenresQuery query)
        {
            return Ok(_queryHandler.HandleQuery(query, search));
        }

        // GET api/<GenresController>/5
        [HttpGet("{id}")]
        [Authorize]
        public IActionResult Get(int id,
                          [FromServices] IFindGenreQuery query)
        {
            return Ok(_queryHandler.HandleQuery(query, id));
        }

        // POST api/<GenresController>
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] CreateGenreDTO dto,
                                 [FromServices] ICreateGenreCommand command)
        {
            command.Execute(dto);
            return StatusCode(201);
        }

        // PATCH api/<GenresController>/5
        [HttpPatch("{id}")]
        public IActionResult Patch(int id,
                                [FromBody] PatchGenreDTO dto,
                                [FromServices] PatchGenreValidator validator)
        {
            var genre = _context.Genres.FirstOrDefault(g => g.ID == id);
            if (genre == null)
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
                genre.Name = dto.Name;
            }
            _context.SaveChanges();
            return NoContent();
        }

        // DELETE api/<GenresController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var genre = _context.Genres.FirstOrDefault(g=>g.ID==id);
            if (genre == null)
            {
                return NotFound();
            }
            _context.Genres.Remove(genre);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
