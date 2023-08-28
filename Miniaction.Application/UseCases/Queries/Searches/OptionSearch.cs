using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miniaction.Application.UseCases.Queries.Searches
{
    public class OptionSearch
    {
        public bool? Available { get; set; }
        public decimal? SmallerPrice { get; set; }
        public decimal? BiggerPrice { get; set; }
        public int? SerialID { get; set; }
        public string SerialTitle { get; set; }
        public int? FormatID { get; set; }
        public string FormatName { get; set; }
    }
}
