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
    public class NetworksController : ControllerBase
    {
        private MiniactionContext _context;
        private IQueryHandler _queryHandler;
        public NetworksController(MiniactionContext context,
                                  IQueryHandler queryHandler)
        {
            _context = context;
            _queryHandler = queryHandler;
        }
        // GET: api/<NetworksController>
        [HttpGet]
        [Authorize]
        public IActionResult Get([FromQuery] NetworkSearch search,
                                 [FromServices] ISearchNetworksQuery query)
        {
            return Ok(_queryHandler.HandleQuery(query, search));
        }

        // GET api/<NetworksController>/5
        [HttpGet("{id}")]
        [Authorize]
        public IActionResult Get(int id,
                                 [FromServices] IFindNetworkQuery query)
        {
            return Ok(_queryHandler.HandleQuery(query,id));
        }

        // POST api/<NetworksController>
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] CreateNetworkDTO dto,
                                 [FromServices] ICreateNetworkCommand command)
        {
            command.Execute(dto);
            return StatusCode(201);
        }

        // PATCH api/<NetworksController>/5
        [HttpPatch("{id}")]
        public IActionResult Patch(int id,
                                [FromBody] PatchNetworkDTO dto,
                                [FromServices] PatchNetworkValidator validator)
        {
            var network = _context.Networks.FirstOrDefault(n => n.ID == id);
            if (network == null)
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
                network.Name = dto.Name;
            }
            _context.SaveChanges();
            return NoContent();
        }

        // DELETE api/<NetworksController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var network = _context.Networks.FirstOrDefault(n=>n.ID==id);
            if (network == null)
            {
                return NotFound();
            }
            _context.Networks.Remove(network);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
