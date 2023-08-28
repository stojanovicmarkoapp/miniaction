using Microsoft.EntityFrameworkCore;
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
    public class EFFindReviewQuery : IFindReviewQuery
    {
        private readonly MiniactionContext _context;
        public EFFindReviewQuery(MiniactionContext context)
        {
            _context = context;
        }
        public int ID => 42;

        public string Name => "Find a review";

        public string Description => "Finds a review.";

        public ReadReviewDTO Execute(int id)
        {
            Review review = _context.Reviews
                              .Include(r => r.Option)
                                .ThenInclude(s=>s.Serial)
                                    .ThenInclude(t=>t.Trailer)
                              .Include(r => r.Option)
                                .ThenInclude(f => f.Format)
                              .Include(r=>r.User)
                                .ThenInclude(a=>a.Avatar)
                              .Include(r=>r.Star)
                              .FirstOrDefault(r => r.ID == id);
            if (review == null)
            {
                throw new Exception("Review is not found.");
            }
            return new ReadReviewDTO
            {
                ID = review.ID,
                ModifiedAt = review.ModifiedAt,
                Comment = review.Comment,
                Option = new ReadOptionDTONutshell2
                {
                    ID = review.Option.ID,
                    SerialTitle = review.Option.Serial.Title,
                    TrailerName = !review.Option.Serial.TrailerID.HasValue ? null :  review.Option.Serial.Trailer.Name,
                    FormatName = review.Option.Format.Name
                },
                User = new ReadUserDTONutshell2
                {
                    ID = review.User.ID,
                    Username = review.User.Username,
                    AvatarName = !review.User.AvatarID.HasValue ? null : review.User.Avatar.Name
                },
                StarScore = review.Star.Score
            };
        }
    }
}
