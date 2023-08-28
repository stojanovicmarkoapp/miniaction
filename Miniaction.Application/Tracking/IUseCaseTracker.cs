using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miniaction.Application.Tracking
{
    public interface IUseCaseTracker
    {
        void Add(UseCaseTrackEntry entry);
    }
}
