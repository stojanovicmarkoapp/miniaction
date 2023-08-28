using Microsoft.AspNetCore.Mvc;
using Miniaction.Application.UseCaseHandling;
using Miniaction.Application.UseCases.Commands;
using Miniaction.Application.UseCases.DTO;
using Miniaction.Application.UseCases.Queries.Searches;
using Miniaction.Application.UseCases.Queries;
using Miniaction.DataAccess;
using Miniaction.Implementation.Validators;
using System.Linq;
using System;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Miniaction.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private MiniactionContext _context;
        private IQueryHandler _queryHandler;
        public ReviewsController(MiniactionContext context,
                                  IQueryHandler queryHandler)
        {
            _context = context;
            _queryHandler = queryHandler;
        }
        // GET: api/<ReviewsController>
        [HttpGet]
        [Authorize]
        public IActionResult Get([FromQuery] ReviewSearch search,
                                 [FromServices] ISearchReviewsQuery query)
        {
            return Ok(_queryHandler.HandleQuery(query, search));
        }

        // GET api/<ReviewsController>/5
        [HttpGet("{id}")]
        [Authorize]
        public IActionResult Get(int id,
                                 [FromServices] IFindReviewQuery query)
        {
            return Ok(_queryHandler.HandleQuery(query, id));
        }

        // POST api/<ReviewsController>
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] CreateReviewDTO dto,
                                  [FromServices] ICreateReviewCommand command)
        {
            command.Execute(dto);
            return StatusCode(201);
        }

        // PATCH api/<ReviewsController>/5
        [HttpPatch("{id}")]
        public IActionResult Patch(int id,
                                [FromBody] PatchReviewDTO dto,
                                [FromServices] PatchReviewValidator validator)
        {
            var review = _context.Reviews.FirstOrDefault(r => r.ID == id);
            if (review == null)
            {
                return NotFound();
            }
            var result = validator.Validate(dto);
            if (!result.IsValid)
            {
                return UnprocessableEntity();
            }
            if (!string.IsNullOrEmpty(dto.Comment))
            {
                review.Comment = dto.Comment;
            }
            if (dto.StarScore.HasValue)
            {
                var starID = _context.Stars.FirstOrDefault(s => s.Score == (int)dto.StarScore).ID;
                review.StarID = starID;
            }
            review.ModifiedAt = DateTime.UtcNow;
            _context.SaveChanges();
            return NoContent();
        }

        // DELETE api/<ReviewsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var review = _context.Reviews.FirstOrDefault(r=>r.ID==id);
            if (review == null)
            {
                return NotFound();
            }
            _context.Reviews.Remove(review);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
