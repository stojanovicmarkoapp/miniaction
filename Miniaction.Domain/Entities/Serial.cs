using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miniaction.Domain.Entities
{
    public class Serial : Entity
    {
        public string Title { get; set; }
        public string Features { get; set; }
        public int Released { get; set; }
        public int PGID { get; set; }
        public int? TrailerID { get; set; }
        public int GenreID { get; set; }
        public int NetworkID { get; set; }
        public virtual PG PG { get; set; }
        public virtual Trailer Trailer { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual Network Network { get; set; }
        public virtual ICollection<Option> Options { get; set; }
    }
}
