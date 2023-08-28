using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Miniaction.API.JWT;
using Miniaction.DataAccess;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Miniaction.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoggingsController : ControllerBase
    {
        private readonly JWTManager _manager;
        public LoggingsController(JWTManager manager)
        {
            _manager = manager;
        }
        // POST api/<LoggingsController>
        [HttpPost]
        public IActionResult Post([FromBody] LoggingRequest request,
                                  [FromServices] MiniactionContext context)
        {
            string token = _manager.MakeToken(request.Designator, request.Password);
            return Ok(new { token });
        }
        [HttpDelete]
        public IActionResult InvalidateToken([FromServices] ITokenStorage storage)
        {
            var header = HttpContext.Request.Headers["Authorization"];
            var token = header.ToString().Split("Bearer ")[1];
            var handler = new JwtSecurityTokenHandler();
            var tokenObject = handler.ReadJwtToken(token);
            string jti = tokenObject.Claims.FirstOrDefault(x => x.Type == "jti").Value;
            storage.InvalidateToken(jti);
            return NoContent();
        }
    }
}
