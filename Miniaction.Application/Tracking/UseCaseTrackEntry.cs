using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miniaction.Application.Tracking
{
    public class UseCaseTrackEntry
    {
        public int ActorID { get; set; }
        public string ActorUsername { get; set; }
        public object Data { get; set; }
        public string UseCaseName { get; set; }
    }
}
