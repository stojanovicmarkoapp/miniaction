using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Miniaction.DataAccess;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Miniaction.API.JWT
{
    public class JWTManager
    {
        private readonly MiniactionContext _context;
        private readonly string _issuer;
        private readonly int _seconds;
        private readonly ITokenStorage _storage;
        private readonly string _secretKey;
        public JWTManager(
            MiniactionContext context,
            string issuer,
            string secretKey,
            int seconds,
            ITokenStorage storage)
        {
            _context = context;
            _issuer = issuer;
            _secretKey = secretKey;
            _seconds = seconds;
            _storage = storage;
        }
        public string MakeToken(string designator, string password)
        {
            var user = _context.Users
                               .Include(x => x.Role)
                                .ThenInclude(x => x.Grants)
                               .FirstOrDefault(x => x.Username == designator || x.EmailAddress == designator);
            if (user == null)
            {
                throw new Exception("User does not exist.");
            }
            var verified = BCrypt.Net.BCrypt.Verify(password, user.Password);
            if (!verified)
            {
                throw new UnauthorizedAccessException("Invalid password.");
            }
            int id = user.ID;
            string username = user.Username;
            List<int> useCaseIDs = user.Role.Grants.Select(x => x.UseCaseID).ToList();
            var tokenID = Guid.NewGuid().ToString();
            _storage.AddToken(tokenID);
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, tokenID, ClaimValueTypes.String, _issuer),
                new Claim(JwtRegisteredClaimNames.Iss, _issuer, ClaimValueTypes.String, _issuer),
                new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64, _issuer),
                new Claim("ID",id.ToString()),
                new Claim("Username",username),
                new Claim("EmailAddress",user.EmailAddress),
                new Claim("RoleID", user.RoleID.ToString()),
                new Claim("UseCaseIDs",JsonConvert.SerializeObject(useCaseIDs))
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var now = DateTime.UtcNow;
            var token = new JwtSecurityToken(
                issuer: _issuer,
                audience: "Any",
                claims : claims,
                notBefore : now,
                expires: now.AddSeconds(_seconds),
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
