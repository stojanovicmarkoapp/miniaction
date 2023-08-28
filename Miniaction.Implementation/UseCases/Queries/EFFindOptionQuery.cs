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
    public class EFFindOptionQuery : IFindOptionQuery
    {
        private readonly MiniactionContext _context;
        public EFFindOptionQuery(MiniactionContext context)
        {
            _context = context;
        }
        public int ID => 36;

        public string Name => "Find an option";

        public string Description => "Finds an option.";

        public ReadOptionDTO Execute(int id)
        {
            Option option = _context.Options
                              .Include(o => o.Serial)
                                .ThenInclude(t=>t.Trailer)
                              .Include(o => o.Format)
                              .Include(o => o.Reviews)
                                .ThenInclude(u => u.User)
                                    .ThenInclude(a=>a.Avatar)
                              .Include(o => o.Reviews)
                                .ThenInclude(u => u.Star)
                              .FirstOrDefault(o => o.ID == id);
            if (option == null)
            {
                throw new Exception("Option is not found.");
            }
            return new ReadOptionDTO
            {
                ID = option.ID,
                Available = option.Available,
                Price = option.Price,
                Serial = new ReadSerialDTONutshell2
                {
                    ID = option.Serial.ID,
                    Title = option.Serial.Title,
                    TrailerName = !option.Serial.TrailerID.HasValue ? null : option.Serial.Trailer.Name
                },
                Format = new ReadFormatDTONutshell
                {
                    ID = option.Format.ID,
                    Name = option.Format.Name
                },
                Reviews = option.Reviews.Select(r => new ReadReviewDTONutshell2
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
            };
        }
    }
}
