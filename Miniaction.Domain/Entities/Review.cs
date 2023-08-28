using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miniaction.Domain.Entities
{
    public class Review : Entity
    {
        public DateTime ModifiedAt { get; set; }
        public string Comment { get; set; }
        public int OptionID { get; set; }
        public int UserID { get; set; }
        public int StarID { get; set; }
        public virtual Option Option { get; set; }
        public virtual User User { get; set; }
        public virtual Star Star { get; set; }
    }
}
