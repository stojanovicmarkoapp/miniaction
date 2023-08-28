using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miniaction.Application.UseCases.DTO
{
    public class ReadOptionDTO
    {
        public int ID { get; set; }
        public bool Available { get; set; }
        public decimal Price { get; set; }
        public ReadSerialDTONutshell2 Serial { get; set; }
        public ReadFormatDTONutshell Format { get; set; }
        public IEnumerable<ReadReviewDTONutshell2> Reviews { get; set; }
    }
}
