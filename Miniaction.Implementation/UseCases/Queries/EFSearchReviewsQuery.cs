using Microsoft.EntityFrameworkCore;
using Miniaction.Application.UseCases.DTO;
using Miniaction.Application.UseCases.Queries;
using Miniaction.Application.UseCases.Queries.Searches;
using Miniaction.DataAccess;
using Miniaction.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miniaction.Implementation.UseCases.Queries
{
    public class EFSearchReviewsQuery : ISearchReviewsQuery
    {
        private readonly MiniactionContext _context;
        public EFSearchReviewsQuery(MiniactionContext context)
        {
            _context = context;
        }
        public int ID => 27;

        public string Name => "Reviews search";

        public string Description => "Searches reviews.";

        public IEnumerable<ReadReviewDTO> Execute(ReviewSearch search)
        {
            var reviews = _context.Reviews.Include(r=>r.Option)
                                            .ThenInclude(s=>s.Serial)
                                                .ThenInclude(t=>t.Trailer)
                                          .Include(r => r.Option)
                                            .ThenInclude(f => f.Format)
                                          .Include(r => r.User)
                                            .ThenInclude(a=>a.Avatar)
                                          .Include(r => r.Star).AsQueryable();
            if (search.ModifiedBefore.HasValue)
            {
                reviews = reviews.Where(r => r.ModifiedAt < (DateTime)search.ModifiedBefore);
            }
            if (search.ModifiedAfter.HasValue)
            {
                reviews = reviews.Where(r => r.ModifiedAt > (DateTime)search.ModifiedAfter);
            }
            if (search.OptionID.HasValue)
            {
                reviews = reviews.Where(r => r.OptionID == (int)search.OptionID);
            }
            if (!string.IsNullOrEmpty(search.SerialTitle))
            {
                reviews = reviews.Where(r => r.Option.Serial.Title.Contains(search.SerialTitle));
            }
            if (!string.IsNullOrEmpty(search.FormatName))
            {
                reviews = reviews.Where(r => r.Option.Format.Name.Contains(search.FormatName));
            }
            if (search.UserID.HasValue)
            {
                reviews = reviews.Where(r => r.UserID == (int)search.UserID);
            }
            if (!string.IsNullOrEmpty(search.Username))
            {
                reviews = reviews.Where(r => r.User.Username.Contains(search.Username));
            }
            if (search.StarScore.HasValue)
            {
                reviews = reviews.Where(r => r.Star.Score == (int)search.StarScore);
            }
            return reviews.Select(r => new ReadReviewDTO
            {
                ID = r.ID,
                ModifiedAt = r.ModifiedAt,
                Comment = r.Comment,
                Option = new ReadOptionDTONutshell2
                {
                    ID = r.Option.ID,
                    SerialTitle = r.Option.Serial.Title,
                    TrailerName = !r.Option.Serial.TrailerID.HasValue ? null : r.Option.Serial.Trailer.Name,
                    FormatName = r.Option.Format.Name
                },
                User = new ReadUserDTONutshell2
                {
                    ID = r.User.ID,
                    Username = r.User.Username,
                    AvatarName = !r.User.AvatarID.HasValue ? null : r.User.Avatar.Name
                },
                StarScore = r.Star.Score
            }).ToList();
        }
    }
}
