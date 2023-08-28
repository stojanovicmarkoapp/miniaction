using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miniaction.Domain.Entities
{
    public class Trailer : File
    {
        public int SerialID { get; set; }
        public virtual Serial Serial { get; set; }
    }
}
