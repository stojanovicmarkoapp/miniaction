using Microsoft.AspNetCore.Mvc;
using Miniaction.Application.UseCaseHandling;
using Miniaction.Application.UseCases.Queries.Searches;
using Miniaction.Application.UseCases.Queries;
using Miniaction.DataAccess;
using Miniaction.Application.UseCases.Commands;
using Miniaction.Application.UseCases.DTO;
using Miniaction.Implementation.Validators;
using System.Linq;
using Miniaction.Implementation.Helpers;
using System.IO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Miniaction.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrailersController : ControllerBase
    {
        private MiniactionContext _context;
        private IQueryHandler _queryHandler;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public TrailersController(MiniactionContext context,
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
        public IActionResult Get([FromQuery] TrailerSearch search,
                                 [FromServices] ISearchTrailersQuery query)
        {
            return Ok(_queryHandler.HandleQuery(query, search));
        }

        // GET api/<TrailersController>/5
        [HttpGet("{id}")]
        [Authorize]
        public IActionResult Get(int id,
                          [FromServices] IFindTrailerQuery query)
        {
            return Ok(_queryHandler.HandleQuery(query, id));
        }

        // POST api/<TrailersController>
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] CreateTrailerDTO dto,
                                 [FromServices] ICreateTrailerCommand command)
        {
            command.Execute(dto);
            return StatusCode(201);
        }

        // PATCH api/<TrailersController>/5
        [HttpPatch("{id}")]
        public IActionResult Patch(int id,
                                [FromBody] PatchFileDTO dto,
                                [FromServices] PatchFileValidator validator)
        {
            var trailer = _context.Trailers.FirstOrDefault(t => t.ID == id);
            if (trailer == null)
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
                string oldName = trailer.Name;
                string fileExtension = "."+oldName.Split(".")[1];
                string newName = FileHelpers.GenerateUniqueFileName(dto.Label,fileExtension);
                //string trailersFolder = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).ToString(), "Miniaction.API\\WWWRoot\\Trailers");
                string trailersFolder = Path.Combine(_hostingEnvironment.WebRootPath, "Trailers");
                string oldFilePath = Path.Combine(trailersFolder, oldName);
                string newFilePath = Path.Combine(trailersFolder, newName);
                System.IO.File.Move(oldFilePath, newFilePath);
                trailer.Name = newName;
            }
            _context.SaveChanges();
            return NoContent();
        }


        // DELETE api/<TrailersController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var trailer = _context.Trailers.FirstOrDefault(t=>t.ID==id);
            if(trailer == null)
            {
                return NotFound();
            }
            string fileName = trailer.Name;
            //string trailersFolder = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).ToString(), "Miniaction.API\\WWWRoot\\Trailers");
            string trailersFolder = Path.Combine(_hostingEnvironment.WebRootPath, "Trailers");
            string filePath = Path.Combine(trailersFolder, fileName);
            System.IO.File.Delete(filePath);
            var serial = _context.Serials.FirstOrDefault(s => s.TrailerID == id);
            serial.TrailerID = null;
            _context.SaveChanges();
            _context.Trailers.Remove(trailer);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
