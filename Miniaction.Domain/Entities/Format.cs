using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miniaction.Domain.Entities
{
    public class Format : Entity
    {
        public string Name { get; set; }
        public virtual ICollection<Option> Options { get; set; }
    }
}
