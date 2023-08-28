using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miniaction.Application.UseCases.DTO
{
    public class CreateReviewDTO
    {
        public string Comment { get; set; }
        public int? OptionID { get; set; }
        public int? UserID { get; set; }
        public int? StarID { get; set; }
    }
}
