using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miniaction.Domain.Entities
{
    public abstract class File : Entity
    {
        public string Name { get; set; }
    }
}
