using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miniaction.Domain.Entities
{
    public class Option : Entity
    {
        public bool Available { get; set; }
        public decimal Price { get; set; }
        public int SerialID { get; set; }
        public int FormatID { get; set; }
        public virtual Serial Serial { get; set; }
        public virtual Format Format { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
