using Miniaction.Application.UseCases.DTO;
using Miniaction.Application.UseCases.Queries.Searches;
using Miniaction.Application.UseCases.Queries;
using Miniaction.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Miniaction.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Miniaction.Implementation.UseCases.Queries
{
    public class EFSearchOptionsQuery : ISearchOptionsQuery
    {
        private readonly MiniactionContext _context;
        public EFSearchOptionsQuery(MiniactionContext context)
        {
            _context = context;
        }
        public int ID => 21;

        public string Name => "Options search";

        public string Description => "Searches options.";

        public IEnumerable<ReadOptionDTO> Execute(OptionSearch search)
        {
            var options = _context.Options.Include(o => o.Serial)
                                            .ThenInclude(t=>t.Trailer)
                                          .Include(o => o.Format)
                                          .Include(o => o.Reviews)
                                            .ThenInclude(u=>u.User)
                                                .ThenInclude(a=>a.Avatar)
                                          .Include(o => o.Reviews)
                                            .ThenInclude(s => s.Star).AsQueryable();
            if (search.Available.HasValue)
            {
                options = options.Where(o => o.Available == (bool)search.Available);
            }
            if (search.SmallerPrice.HasValue)
            {
                options = options.Where(o => o.Price < (decimal)search.SmallerPrice);
            }
            if (search.BiggerPrice.HasValue)
            {
                options = options.Where(o => o.Price > (decimal)search.BiggerPrice);
            }
            if (search.SerialID.HasValue)
            {
                options = options.Where(o => o.SerialID == (int)search.SerialID);
            }
            if (!string.IsNullOrEmpty(search.SerialTitle))
            {
                options = options.Where(o => o.Serial.Title.Contains(search.SerialTitle));
            }
            if (search.FormatID.HasValue)
            {
                options = options.Where(o => o.FormatID == (int)search.FormatID);
            }
            if (!string.IsNullOrEmpty(search.FormatName))
            {
                options = options.Where(o => o.Format.Name.Contains(search.FormatName));
            }
            return options.Select(o => new ReadOptionDTO
            {
                ID = o.ID,
                Available = o.Available,
                Price = o.Price,
                Serial = new ReadSerialDTONutshell2
                {
                    ID = o.Serial.ID,
                    Title = o.Serial.Title,
                    TrailerName = !o.Serial.TrailerID.HasValue ? null : o.Serial.Trailer.Name
                },
                Format = new ReadFormatDTONutshell
                {
                    ID = o.Format.ID,
                    Name = o.Format.Name
                },
                Reviews = o.Reviews.Select(r => new ReadReviewDTONutshell2
                {
                    ID = r.ID,
                    ModifiedAt = r.ModifiedAt,
                    Comment = r.Comment,
                    User = new ReadUserDTONutshell2
                    {
                        ID = r.User.ID,
                        Username = r.User.Username,
                        AvatarName = r.User.Avatar.Name
                    },
                    StarScore = r.Star.Score
                }).ToList()
            }).ToList();
        }
    }
}
