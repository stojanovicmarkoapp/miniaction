using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miniaction.Domain.Entities
{
    public class Grant : Entity
    {
        public int RoleID { get; set; }
        public int UseCaseID { get; set; }
        public virtual Role Role { get; set; }
    }
}
