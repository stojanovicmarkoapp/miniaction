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
using Miniaction.Domain.Entities;
using System.Collections;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Miniaction.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private MiniactionContext _context;
        private IQueryHandler _queryHandler;
        public RolesController(MiniactionContext context,
                                  IQueryHandler queryHandler)
        {
            _context = context;
            _queryHandler = queryHandler;
        }
        // GET: api/<RolesController>
        [HttpGet]
        [Authorize]
        public IActionResult Get([FromQuery] RoleSearch search,
                                 [FromServices] ISearchRolesQuery query)
        {
            return Ok(_queryHandler.HandleQuery(query, search));
        }

        // GET api/<RolesController>/5
        [HttpGet("{id}")]
        [Authorize]
        public IActionResult Get(int id,
                                 [FromServices] IFindRoleQuery query)
        {
            return Ok(_queryHandler.HandleQuery(query, id));
        }

        // POST api/<RolesController>
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] CreateRoleDTO dto,
                                  [FromServices] ICreateRoleCommand command)
        {
            command.Execute(dto);
            return StatusCode(201);
        }

        // PATCH api/<RolesController>/5
        [HttpPatch("{id}")]
        public IActionResult Patch(int id,
                                [FromBody] PatchRoleDTO dto,
                                [FromServices] PatchRoleValidator validator)
        {
            var role = _context.Roles
                               .Include(r=>r.Grants).FirstOrDefault(r => r.ID == id);
            if (role == null)
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
                role.Name = dto.Name;
            }
            if(dto.UseCaseIDs != null)
            {
                var oldUseCaseIDs = role.Grants.Select(x => x.UseCaseID);
                var listedUseCaseIDs = dto.UseCaseIDs;
                var newUseCaseIDs = listedUseCaseIDs.Except(oldUseCaseIDs);
                var useCaseIDsToDelete = oldUseCaseIDs.Except(listedUseCaseIDs);
                var useCaseIDsToPreserve = oldUseCaseIDs.Except(useCaseIDsToDelete);
                var grantsToDelete = _context.Grants
                                     .Where(g => g.RoleID == role.ID && useCaseIDsToDelete.Contains(g.UseCaseID))
                                     .ToList();
                _context.Grants.RemoveRange(grantsToDelete);
                _context.SaveChanges();
                var newGrants = newUseCaseIDs.Select(u => new Grant
                {
                    RoleID = role.ID,
                    UseCaseID = u
                }).ToList();
                _context.Grants.AddRange(newGrants);
                _context.SaveChanges();
            }
            _context.SaveChanges();
            return NoContent();
        }

        // DELETE api/<RolesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var role = _context.Roles
                               .Include(r=>r.Grants).FirstOrDefault(r=>r.ID==id);
            if (role == null)
            {
                return NotFound();
            }
            var grants = _context.Grants.Where(g => g.RoleID == role.ID);
            _context.RemoveRange(grants);
            _context.SaveChanges();
            _context.Roles.Remove(role);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
