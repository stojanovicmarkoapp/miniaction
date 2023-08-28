using Microsoft.AspNetCore.Mvc;
using Miniaction.Application.UseCaseHandling;
using Miniaction.Application.UseCases.Queries.Searches;
using Miniaction.Application.UseCases.Queries;
using Miniaction.DataAccess;
using Miniaction.Application.UseCases.Commands;
using Miniaction.Application.UseCases.DTO;
using Miniaction.Implementation.Validators;
using System.Linq;
using System;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Miniaction.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PGsController : ControllerBase
    {
        private MiniactionContext _context;
        private IQueryHandler _queryHandler;
        public PGsController(MiniactionContext context,
                                  IQueryHandler queryHandler)
        {
            _context = context;
            _queryHandler = queryHandler;
        }
        // GET: api/<PGsController>
        [HttpGet]
        [Authorize]
        public IActionResult Get([FromQuery] PGSearch search,
                                 [FromServices] ISearchPGsQuery query)
        {
            return Ok(_queryHandler.HandleQuery(query, search));
        }

        // GET api/<PGsController>/5
        [HttpGet("{id}")]
        [Authorize]
        public IActionResult Get(int id,
                          [FromServices] IFindPGQuery query)
        {
            return Ok(_queryHandler.HandleQuery(query, id));
        }

        // POST api/<PGsController>
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] CreatePGDTO dto,
                                 [FromServices] ICreatePGCommand command)
        {
            command.Execute(dto);
            return StatusCode(201);
        }

        // PATCH api/<PGsController>/5
        [HttpPatch("{id}")]
        public IActionResult Patch(int id,
                                [FromBody] PatchPGDTO dto,
                                [FromServices] PatchPGValidator validator)
        {
            var pg = _context.PGs.FirstOrDefault(p => p.ID == id);
            if (pg == null)
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
                pg.Name = dto.Name;
            }
            if (!string.IsNullOrEmpty(dto.Description))
            {
                pg.Description = dto.Description;
            }
            _context.SaveChanges();
            return NoContent();
        }

        // DELETE api/<PGsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var pg = _context.PGs.FirstOrDefault(p=>p.ID==id);
            if (pg == null)
            {
                return NotFound();
            }
            _context.PGs.Remove(pg);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
