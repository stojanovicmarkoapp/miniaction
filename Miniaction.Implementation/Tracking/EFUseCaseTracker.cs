using Miniaction.Application.Tracking;
using Miniaction.DataAccess;
using Miniaction.Domain.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miniaction.Implementation.Tracking
{
    public class EFUseCaseTracker : IUseCaseTracker
    {
        private readonly MiniactionContext _context;
        public EFUseCaseTracker(MiniactionContext context)
        {
            _context = context;
        }
        public void Add(UseCaseTrackEntry entry)
        {
            _context.TrackEntries.Add(new TrackEntry
            {
                ActorID = entry.ActorID,
                ActorUsername = entry.ActorUsername,
                UseCaseName = entry.UseCaseName,
                UseCaseData = JsonConvert.SerializeObject(entry.Data),
                CreatedAt = DateTime.UtcNow
            });
            _context.SaveChanges();
        }
    }
}
