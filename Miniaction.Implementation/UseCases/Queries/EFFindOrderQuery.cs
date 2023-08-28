using Miniaction.Application.UseCases.DTO;
using Miniaction.Application.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Miniaction.Application.UseCases.Queries;
using Miniaction.DataAccess;
using Miniaction.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Miniaction.Implementation.UseCases.Queries
{
    public class EFFindOrderQuery : IFindOrderQuery
    {
        private readonly MiniactionContext _context;
        public EFFindOrderQuery(MiniactionContext context)
        {
            _context = context;
        }
        public int ID => 40;

        public string Name => "Find an order";

        public string Description => "Finds an order.";

        public ReadOrderDTO Execute(int id)
        {
            Order order = _context.Orders
                              .Include(o => o.Option)
                                .ThenInclude(s=>s.Serial)
                                    .ThenInclude(t=>t.Trailer)
                              .Include(o => o.Option)
                                .ThenInclude(s => s.Format)
                              .Include(o => o.User)
                                .ThenInclude(a=>a.Avatar)
                              .FirstOrDefault(o => o.ID == id);
            if (order == null)
            {
                throw new Exception("Order is not found.");
            }
            return new ReadOrderDTO
            {
                ID = order.ID,
                OrderedAt = order.OrderedAt,
                PaidAt = order.PaidAt,
                Paid = order.Paid,
                Quantity = order.Quantity,
                Price = order.Price,
                Value = order.Quantity * order.Price,
                Option = new ReadOptionDTONutshell2
                {
                    ID = order.Option.ID,
                    SerialTitle = order.Option.Serial.Title,
                    TrailerName = !order.Option.Serial.TrailerID.HasValue ? null : order.Option.Serial.Trailer.Name,
                    FormatName = order.Option.Format.Name
                },
                User = new ReadUserDTONutshell2
                {
                    ID = order.User.ID,
                    Username = order.User.Username,
                    AvatarName = !order.User.AvatarID.HasValue ? null : order.User.Avatar.Name
                }
            };
        }
    }
}
