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
    public class EFSearchUsersQuery : ISearchUsersQuery
    {
        private readonly MiniactionContext _context;
        public EFSearchUsersQuery(MiniactionContext context)
        {
            _context = context;
        }
        public int ID => 23;

        public string Name => "Users search";

        public string Description => "Searches users.";

        public IEnumerable<ReadUserDTO> Execute(UserSearch search)
        {
            var users = _context.Users.Include(u=>u.Avatar)
                                      .Include(u => u.Role)
                                      .Include(u => u.Orders)
                                        .ThenInclude(o=>o.Option)
                                            .ThenInclude(s=>s.Serial)
                                                .ThenInclude(t=>t.Trailer)
                                       .Include(u => u.Orders)
                                        .ThenInclude(o => o.Option)
                                            .ThenInclude(f=>f.Format)
                                      .Include(u => u.Reviews)
                                        .ThenInclude(o => o.Star).AsQueryable();
            if (!string.IsNullOrEmpty(search.Username))
            {
                users = users.Where(u => u.Username.Contains(search.Username));
            }
            if (!string.IsNullOrEmpty(search.FirstName))
            {
                users = users.Where(u => u.FirstName.Contains(search.FirstName));
            }
            if (!string.IsNullOrEmpty(search.LastName))
            {
                users = users.Where(u => u.LastName.Contains(search.LastName));
            }
            if (search.Sex.HasValue)
            {
                users = users.Where(u => u.Sex==(char)search.Sex);
            }
            if (!string.IsNullOrEmpty(search.EmailAddress))
            {
                users = users.Where(u => u.EmailAddress.Contains(search.EmailAddress));
            }
            if (!string.IsNullOrEmpty(search.HomeAddress))
            {
                users = users.Where(u => u.HomeAddress.Contains(search.HomeAddress));
            }
            if (search.RoleID.HasValue)
            {
                users = users.Where(u => u.RoleID == (int)search.RoleID);
            }
            return users.Select(u => new ReadUserDTO
            {
                ID = u.ID,
                Username = u.Username,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Sex = u.Sex,
                EmailAddress = u.EmailAddress,
                HomeAddress = u.HomeAddress,
                Password = u.Password,
                AvatarName = !u.AvatarID.HasValue ? null : u.Avatar.Name,
                Role = new ReadRoleDTONutshell
                {
                    ID = u.Role.ID,
                    Name = u.Role.Name
                },
                Orders = u.Orders.Select(o => new ReadOrderDTONutshell
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
                Reviews = u.Reviews.Select(r => new ReadReviewDTONutshell
                {
                    ID = r.ID,
                    ModifiedAt = r.ModifiedAt,
                    Comment = r.Comment,
                    StarScore = r.Star.Score
                }).ToList()
            }).ToList();
        }
    }
}
