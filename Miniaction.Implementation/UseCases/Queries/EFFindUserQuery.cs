using Microsoft.EntityFrameworkCore;
using Miniaction.Application.UseCases.DTO;
using Miniaction.Application.UseCases.Queries;
using Miniaction.DataAccess;
using Miniaction.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Miniaction.Implementation.UseCases.Queries
{
    public class EFFindUserQuery : IFindUserQuery
    {
        private readonly MiniactionContext _context;
        public EFFindUserQuery(MiniactionContext context)
        {
            _context = context;
        }
        public int ID => 38;

        public string Name => "Find a user";

        public string Description => "Finds a user.";

        public ReadUserDTO Execute(int id)
        {
            User user = _context.Users
                              .Include(u => u.Avatar)
                              .Include(u => u.Role)
                              .Include(u => u.Orders)
                                .ThenInclude(o=>o.Option)
                                    .ThenInclude(s=>s.Serial)
                                        .ThenInclude(t=>t.Trailer)
                              .Include(u => u.Orders)
                                .ThenInclude(o => o.Option)
                                    .ThenInclude(f => f.Format)
                              .Include(u => u.Reviews)
                                .ThenInclude(s => s.Star)
                              .FirstOrDefault(u => u.ID == id);
            if (user == null)
            {
                throw new Exception("User is not found.");
            }
            return new ReadUserDTO
            {
                ID = user.ID,
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Sex = user.Sex,
                EmailAddress = user.EmailAddress,
                HomeAddress = user.HomeAddress,
                Password = user.Password,
                AvatarName = !user.AvatarID.HasValue ? null : user.Avatar.Name,
                Role = new ReadRoleDTONutshell
                {
                    ID = user.Role.ID,
                    Name = user.Role.Name
                },
                Orders = user.Orders.Select(o => new ReadOrderDTONutshell
                {
                    ID = o.ID,
                    PaidAt = o.PaidAt,
                    Paid = o.Paid,
                    Quantity = o.Quantity,
                    Price = o.Price,
                    Value = o.Quantity * o.Price,
                    Option = new ReadOptionDTONutshell2
                    {
                        ID = o.Option.ID,
                        SerialTitle = o.Option.Serial.Title,
                        TrailerName = !o.Option.Serial.TrailerID.HasValue ? null : o.Option.Serial.Trailer.Name,
                        FormatName = o.Option.Format.Name
                    }
                }).ToList(),
                Reviews = user.Reviews.Select(r => new ReadReviewDTONutshell
                {
                    ID = r.ID,
                    ModifiedAt = r.ModifiedAt,
                    Comment = r.Comment,
                    StarScore = r.Star.Score
                }).ToList()
            };
        }
    }
}
