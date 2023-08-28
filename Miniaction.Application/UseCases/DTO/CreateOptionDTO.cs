using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miniaction.Application.UseCases.DTO
{
    public class CreateOptionDTO
    {
        public bool? Available { get; set; }
        public decimal? Price { get; set; }
        public int? SerialID { get; set; }
        public int? FormatID { get; set; }
    }
}
