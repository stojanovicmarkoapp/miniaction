using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miniaction.Domain.Entities
{
    public class User : Entity
    {
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public char Sex { get; set; }
        public string EmailAddress { get; set; }
        public string HomeAddress { get; set; }
        public string Password { get; set; }
        public int RoleID { get; set; }
        public int? AvatarID { get; set; }
        public virtual Role Role { get; set; }
        public virtual Avatar Avatar { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }

    }
}
