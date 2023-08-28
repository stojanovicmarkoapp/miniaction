using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miniaction.Application.UseCases.Queries.Searches
{
    public class ReviewSearch
    {
        public DateTime? ModifiedBefore { get; set; }
        public DateTime? ModifiedAfter { get; set; }
        public int? OptionID { get; set; }
        public string SerialTitle { get; set; }
        public string FormatName { get; set; }
        public int? UserID { get; set; }
        public string Username { get; set; }
        public int? StarScore { get; set; }
    }
}
