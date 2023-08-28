using Microsoft.AspNetCore.Mvc;
using Miniaction.Application.UseCaseHandling;
using Miniaction.Application.UseCases.Queries.Searches;
using Miniaction.Application.UseCases.Queries;
using Miniaction.DataAccess;
using Miniaction.Application.UseCases.Commands;
using Miniaction.Application.UseCases.DTO;
using Miniaction.Implementation.Validators;
using System.Linq;
using System.IO;
using Miniaction.Implementation.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Miniaction.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvatarsController : ControllerBase
    {
        private MiniactionContext _context;
        private IQueryHandler _queryHandler;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public AvatarsController( MiniactionContext context,
                                  IQueryHandler queryHandler,
                                  IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _queryHandler = queryHandler;
            _hostingEnvironment = hostingEnvironment;
        }
        // GET: api/<TrailersController>
        [HttpGet]
        [Authorize]
        public IActionResult Get([FromQuery] AvatarSearch search,
                                 [FromServices] ISearchAvatarsQuery query)
        {
            return Ok(_queryHandler.HandleQuery(query, search));
        }

        // GET api/<TrailersController>/5
        [HttpGet("{id}")]
        [Authorize]
        public IActionResult Get(int id,
                          [FromServices] IFindAvatarQuery query)
        {
            return Ok(_queryHandler.HandleQuery(query, id));
        }

        // POST api/<AvatarsController>
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] CreateAvatarDTO dto,
                                 [FromServices] ICreateAvatarCommand command)
        {
            command.Execute(dto);
            return StatusCode(201);
        }

        // PATCH api/<AvatarsController>/5
        [HttpPatch("{id}")]
        public IActionResult Patch(int id,
                                [FromBody] PatchFileDTO dto,
                                [FromServices] PatchFileValidator validator)
        {
            var avatar = _context.Avatars.FirstOrDefault(a => a.ID == id);
            if (avatar == null)
            {
                return NotFound();
            }
            var result = validator.Validate(dto);
            if (!result.IsValid)
            {
                return UnprocessableEntity();
            }
            if (!string.IsNullOrEmpty(dto.Label))
            {
                string oldName = avatar.Name;
                string fileExtension = "." + oldName.Split(".")[1];
                string newName = FileHelpers.GenerateUniqueFileName(dto.Label, fileExtension);
                //string avatarsFolder = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).ToString(), "Miniaction.API\\WWWRoot\\Avatars");
                string avatarsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "Avatars");
                string oldFilePath = Path.Combine(avatarsFolder, oldName);
                string newFilePath = Path.Combine(avatarsFolder, newName);
                System.IO.File.Move(oldFilePath, newFilePath);
                avatar.Name = newName;
            }
            _context.SaveChanges();
            return NoContent();
        }

        // DELETE api/<TrailersController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var avatar = _context.Avatars.FirstOrDefault(a=>a.ID==id);
            if (avatar == null)
            {
                return NotFound();
            }
            string fileName = avatar.Name;
            //string avatarsFolder = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).ToString(), "Miniaction.API\\WWWRoot\\Avatars");
            string avatarsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "Avatars");
            string filePath = Path.Combine(avatarsFolder, fileName);
            System.IO.File.Delete(filePath);
            var user = _context.Users.FirstOrDefault(u => u.AvatarID == id);
            user.AvatarID = null;
            _context.SaveChanges();
            _context.Avatars.Remove(avatar);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
