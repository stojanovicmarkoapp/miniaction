using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miniaction.Domain.Entities
{
    public class Avatar : File
    {
        public int UserID { get; set; }
        public virtual User User { get; set; }
    }
}
