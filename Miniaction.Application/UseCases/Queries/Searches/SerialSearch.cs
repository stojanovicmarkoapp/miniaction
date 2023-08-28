using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miniaction.Application.UseCases.Queries.Searches
{
    public class SerialSearch
    {
        public string Title { get; set; }
        public int? Released { get; set; }
        public int? PGID { get; set; }
        public string PGName { get; set; }
        public int? GenreID { get; set; }
        public string GenreName { get; set; }
        public int? NetworkID { get; set; }
        public string NetworkName { get; set; }
    }
}
