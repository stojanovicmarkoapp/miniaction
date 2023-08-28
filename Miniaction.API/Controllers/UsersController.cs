using Microsoft.AspNetCore.Mvc;
using Miniaction.Application.UseCaseHandling;
using Miniaction.Application.UseCases.Commands;
using Miniaction.Application.UseCases.DTO;
using Miniaction.Application.UseCases.Queries.Searches;
using Miniaction.Application.UseCases.Queries;
using Miniaction.DataAccess;
using Miniaction.Implementation.Validators;
using System.Linq;
using Miniaction.Domain.Entities;
using Miniaction.Implementation.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Miniaction.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private MiniactionContext _context;
        private IQueryHandler _queryHandler;
        public UsersController(MiniactionContext context,
                                  IQueryHandler queryHandler)
        {
            _context = context;
            _queryHandler = queryHandler;
        }
        // GET: api/<UsersController>
        [HttpGet]
        [Authorize]
        public IActionResult Get([FromQuery] UserSearch search,
                                 [FromServices] ISearchUsersQuery query)
        {
            return Ok(_queryHandler.HandleQuery(query, search));
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        [Authorize]
        public IActionResult Get(int id,
                                 [FromServices] IFindUserQuery query)
        {
            return Ok(_queryHandler.HandleQuery(query, id));
        }

        // POST api/<UsersController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateUserDTO dto,
                                  [FromServices] ICreateUserCommand command)
        {
            command.Execute(dto);
            return StatusCode(201);
        }

        // PATCH api/<UsersController>/5
        [HttpPatch("{id}")]
        public IActionResult Patch(int id,
                                [FromBody] PatchUserDTO dto,
                                [FromServices] PatchUserValidator validator)
        {
            var user = _context.Users.FirstOrDefault(u => u.ID == id);
            if (user == null)
            {
                return NotFound();
            }
            var result = validator.Validate(dto);
            if (!result.IsValid)
            {
                return UnprocessableEntity();
            }
            if (!string.IsNullOrEmpty(dto.Username))
            {
                user.Username = dto.Username;
            }
            if (!string.IsNullOrEmpty(dto.FirstName))
            {
                user.FirstName = dto.FirstName;
            }
            if (!string.IsNullOrEmpty(dto.LastName))
            {
                user.LastName = dto.LastName;
            }
            if (dto.Sex.HasValue)
            {
                user.Sex = (char)dto.Sex;
            }
            if (!string.IsNullOrEmpty(dto.EmailAddress))
            {
                user.EmailAddress = dto.EmailAddress;
            }
            if (!string.IsNullOrEmpty(dto.HomeAddress))
            {
                user.HomeAddress = dto.HomeAddress;
            }
            if (!string.IsNullOrEmpty(dto.Password))
            {
                //user.Password = HashHelpers.HashToSHA512(dto.Password);
                user.Password = BCrypt.Net.BCrypt.HashPassword(dto.Password);
            }
            if (dto.RoleID.HasValue)
            {
                user.RoleID = (int)dto.RoleID;
            }
            _context.SaveChanges();
            return NoContent();
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = _context.Users.FirstOrDefault(u=>u.ID==id);
            if (user == null)
            {
                return NotFound();
            }
            _context.Users.Remove(user);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
