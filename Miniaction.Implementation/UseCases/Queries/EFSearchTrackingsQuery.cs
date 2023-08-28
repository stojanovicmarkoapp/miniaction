using Miniaction.Application.UseCases.DTO;
using Miniaction.Application.UseCases.Queries.Searches;
using Miniaction.Application.UseCases.Queries;
using Miniaction.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miniaction.Implementation.UseCases.Queries
{
    public class EFSearchTrackingsQuery : ISearchTrackingsQuery
    {
        private readonly MiniactionContext _context;
        public EFSearchTrackingsQuery(MiniactionContext context)
        {
            _context = context;
        }
        public int ID => 29;

        public string Name => "Trackings search";

        public string Description => "Searches trackings.";

        public IEnumerable<ReadTrackingDTO> Execute(TrackingSearch search)
        {
            var trackings = _context.TrackEntries.AsQueryable();
            if (search.CreatedBefore.HasValue)
            {
                trackings = trackings.Where(t => t.CreatedAt < (DateTime)search.CreatedBefore);
            }
            if (search.CreatedAfter.HasValue)
            {
                trackings = trackings.Where(t => t.CreatedAt > (DateTime)search.CreatedAfter);
            }
            if (search.ActorID.HasValue)
            {
                trackings = trackings.Where(t => t.ActorID == (int)search.ActorID);
            }
            if (!string.IsNullOrEmpty(search.ActorUsername))
            {
                trackings = trackings.Where(t => t.ActorUsername.Contains(search.ActorUsername));
            }
            if (!string.IsNullOrEmpty(search.UseCaseName))
            {
                trackings = trackings.Where(t => t.UseCaseName.Contains(search.UseCaseName));
            }
            return trackings.Select(t => new ReadTrackingDTO
            {
                ID = t.ID,
                ActorID = t.ActorID,
                ActorUsername = t.ActorUsername,
                UseCaseName = t.UseCaseName,
                UseCaseData = t.UseCaseData,
                CreatedAt = t.CreatedAt
            }).ToList();
        }
    }
}
