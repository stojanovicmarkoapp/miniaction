using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miniaction.Application.UseCases.DTO
{
    public class PatchUserDTO
    {
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public char? Sex { get; set; }
        public string EmailAddress { get; set; }
        public string HomeAddress { get; set; }
        public string Password { get; set; }
        public int? RoleID { get; set; }
    }
}
