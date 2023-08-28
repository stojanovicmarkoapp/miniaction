using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miniaction.Application.UseCases.DTO
{
    public class PatchReviewDTO
    {
        public string Comment { get; set; }
        public int? StarScore { get; set; }
    }
}
