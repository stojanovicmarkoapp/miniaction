using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miniaction.Application.UseCases.DTO
{
    public class PatchOrderDTO
    {
        public DateTime? PaidAt { get; set; }
        public bool? Paid { get; set; }
        public int? Quantity { get; set; }
        public decimal? Price { get; set; }
    }
}
