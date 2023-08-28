using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miniaction.Domain.Entities
{
    public class TrackEntry : Entity
    {
        public int ActorID { get; set; }
        public string ActorUsername { get; set; }
        public string UseCaseName { get; set; }
        public string UseCaseData { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
