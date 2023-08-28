using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miniaction.Application.UseCases.Queries.Searches
{
    public class TrackingSearch
    {
        public int? ActorID { get; set; }
        public string ActorUsername { get; set; }
        public string UseCaseName { get; set; }
        public DateTime? CreatedBefore { get; set; }
        public DateTime? CreatedAfter { get; set; }
    }
}
