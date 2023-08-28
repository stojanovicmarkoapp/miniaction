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
    public class EFSearchOrdersQuery : ISearchOrdersQuery
    {
        private readonly MiniactionContext _context;
        public EFSearchOrdersQuery(MiniactionContext context)
        {
            _context = context;
        }
        public int ID => 25;

        public string Name => "Orders search";

        public string Description => "Searches orders.";

        public IEnumerable<ReadOrderDTO> Execute(OrderSearch search)
        {
            var orders = _context.Orders.Include(o=>o.Option)
                                            .ThenInclude(s=>s.Serial)
                                                .ThenInclude(t=>t.Trailer)
                                        .Include(o => o.Option)
                                            .ThenInclude(f => f.Format)
                                        .Include(o => o.User)
                                            .ThenInclude(a=>a.Avatar).AsQueryable();
            if (search.OrderedBefore.HasValue)
            {
                orders = orders.Where(o => o.OrderedAt < (DateTime)search.OrderedBefore);
            }
            if (search.OrderedAfter.HasValue)
            {
                orders = orders.Where(o => o.OrderedAt > (DateTime)search.OrderedAfter);
            }
            if (search.Paid.HasValue)
            {
                orders = orders.Where(o => o.Paid == (bool)search.Paid);
            }
            if (search.LessQuantity.HasValue)
            {
                orders = orders.Where(o => o.Quantity < (int)search.LessQuantity);
            }
            if (search.MoreQuantity.HasValue)
            {
                orders = orders.Where(o => o.Quantity > (int)search.MoreQuantity);
            }
            if (search.SmallerPrice.HasValue)
            {
                orders = orders.Where(o => o.Price < (decimal)search.SmallerPrice);
            }
            if (search.BiggerPrice.HasValue)
            {
                orders = orders.Where(o => o.Price > (decimal)search.BiggerPrice);
            }
            if (search.SmallerValue.HasValue)
            {
                orders = orders.Where(o => o.Quantity * o.Price < (decimal)search.SmallerValue);
            }
            if (search.BiggerValue.HasValue)
            {
                orders = orders.Where(o => o.Quantity * o.Price > (decimal)search.BiggerValue);
            }
            if (search.OptionID.HasValue)
            {
                orders = orders.Where(o => o.OptionID == (int)search.OptionID);
            }
            if (!string.IsNullOrEmpty(search.SerialTitle))
            {
                orders = orders.Where(o => o.Option.Serial.Title.Contains(search.SerialTitle));
            }
            if (!string.IsNullOrEmpty(search.FormatName))
            {
                orders = orders.Where(o => o.Option.Format.Name.Contains(search.FormatName));
            }
            if (search.UserID.HasValue)
            {
                orders = orders.Where(o => o.UserID == (int)search.UserID);
            }
            if (!string.IsNullOrEmpty(search.Username))
            {
                orders = orders.Where(o => o.User.Username.Contains(search.Username));
            }
            return orders.Select(o => new ReadOrderDTO
            {
                ID = o.ID,
                OrderedAt = o.OrderedAt,
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
                },
                User = new ReadUserDTONutshell2
                {
                    ID = o.User.ID,
                    Username = o.User.Username,
                    AvatarName = !o.User.AvatarID.HasValue ? null : o.User.Avatar.Name
                }
            }).ToList();
        }
    }
}
