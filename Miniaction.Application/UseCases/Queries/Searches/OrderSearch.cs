using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miniaction.Application.UseCases.Queries.Searches
{
    public class OrderSearch
    {
        public DateTime? OrderedBefore { get; set; }
        public DateTime? OrderedAfter { get; set; }
        public bool? Paid { get; set; }
        public int? LessQuantity { get; set; }
        public int? MoreQuantity { get; set; }
        public decimal? SmallerPrice { get; set; }
        public decimal? BiggerPrice { get; set; }
        public decimal? SmallerValue { get; set; }
        public decimal? BiggerValue { get; set; }
        public int? OptionID { get; set; }
        public string SerialTitle { get; set; }
        public string FormatName { get; set; }
        public int? UserID { get; set; }
        public string Username { get; set; }
    }
}
