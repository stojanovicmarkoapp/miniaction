using FluentValidation;
using Miniaction.Implementation.Helpers;
using Miniaction.Application.UseCases.Commands;
using Miniaction.Application.UseCases.DTO;
using Miniaction.DataAccess;
using Miniaction.Domain.Entities;
using Miniaction.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miniaction.Implementation.UseCases.Commands
{
    public class EFCreateOrderCommand : EFUseCase, ICreateOrderCommand
    {
        private CreateOrderValidator _validator;
        public EFCreateOrderCommand(
                MiniactionContext context,
                CreateOrderValidator validator
            )
            : base(context)
        {
            _validator = validator;
        }
        public int ID => 11;
        public string Name => "Create an order";
        public string Description => "Creates an order.";
        public void Execute(CreateOrderDTO request)
        {
            _validator.ValidateAndThrow(request);
            decimal price = Context.Options.FirstOrDefault(o => o.ID == (int)request.OptionID).Price;
            Order order = new Order();
            order.OrderedAt = DateTime.UtcNow;
            order.Paid = false;
            order.Quantity = (int)request.Quantity;
            order.Price = price;
            order.OptionID = (int)request.OptionID;
            order.UserID = (int)request.UserID;
            Context.Add(order);
            Context.SaveChanges();
        }
    }
}
