using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miniaction.Application.UseCases.DTO
{
    public class CreateOrderDTO
    {
        public int? Quantity { get; set; }
        public int? OptionID { get; set; }
        public int? UserID { get; set; }
    }
}
