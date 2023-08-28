using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miniaction.Domain.Entities
{
    public class PG : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Serial> Serials { get; set; }
    }
}
