using Miniaction.Application.UseCases.DTO;
using Miniaction.Application.UseCases.Queries;
using Miniaction.DataAccess;
using Miniaction.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miniaction.Implementation.UseCases.Queries
{
    public class EFFindTrackingQuery : IFindTrackingQuery
    {
        private readonly MiniactionContext _context;
        public EFFindTrackingQuery(MiniactionContext context)
        {
            _context = context;
        }
        public int ID => 44;

        public string Name => "Find tracking";

        public string Description => "Finds a tracking.";

        public ReadTrackingDTO Execute(int id)
        {
            TrackEntry tracking = _context.TrackEntries
                              .FirstOrDefault(t => t.ID == id);
            if (tracking == null)
            {
                throw new Exception("Tracking is not found.");
            }
            return new ReadTrackingDTO
            {
                ID = tracking.ID,
                ActorID = tracking.ActorID,
                ActorUsername = tracking.ActorUsername,
                UseCaseName = tracking.UseCaseName,
                UseCaseData = tracking.UseCaseData,
                CreatedAt = tracking.CreatedAt
            };
        }
    }
}
