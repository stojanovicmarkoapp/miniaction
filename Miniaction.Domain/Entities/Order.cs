using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miniaction.Domain.Entities
{
    public class Order : Entity
    {
        public DateTime OrderedAt { get; set; }
        public DateTime? PaidAt { get; set; }
        public bool Paid { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int OptionID { get; set; }
        public int UserID { get; set; }
        public virtual Option Option { get; set; }
        public virtual User User { get; set; }
    }
}
