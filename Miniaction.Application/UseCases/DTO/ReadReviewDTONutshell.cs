using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miniaction.Application.UseCases.DTO
{
    public class ReadReviewDTONutshell
    {
        public int ID { get; set; }
        public DateTime ModifiedAt { get; set; }
        public string Comment { get; set; }
        public int StarScore { get; set; }
    }
}
