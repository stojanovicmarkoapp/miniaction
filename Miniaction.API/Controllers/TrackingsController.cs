using Microsoft.AspNetCore.Mvc;
using Miniaction.Application.UseCases.Queries.Searches;
using Miniaction.Application.UseCases.Queries;
using Miniaction.Application.UseCaseHandling;
using Miniaction.DataAccess;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Miniaction.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TrackingsController : ControllerBase
    {
        private MiniactionContext _context;
        private IQueryHandler _queryHandler;
        public TrackingsController(MiniactionContext context,
                                  IQueryHandler queryHandler)
        {
            _context = context;
            _queryHandler = queryHandler;
        }
        // GET: api/<TrackingsController>
        [HttpGet]
        public IActionResult Get([FromQuery] TrackingSearch search,
                                 [FromServices] ISearchTrackingsQuery query)
        {
            return Ok(_queryHandler.HandleQuery(query, search));
        }

        // GET api/<TrackingsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id,
                          [FromServices] IFindTrackingQuery query)
        {
            return Ok(_queryHandler.HandleQuery(query, id));
        }
    }
}
