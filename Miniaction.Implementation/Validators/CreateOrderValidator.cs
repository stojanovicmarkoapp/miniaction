using FluentValidation;
using Miniaction.Application.UseCases.DTO;
using Miniaction.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miniaction.Implementation.Validators
{
    public class CreateOrderValidator : AbstractValidator<CreateOrderDTO>
    {
        public CreateOrderValidator(MiniactionContext context)
        {
            RuleLevelCascadeMode = CascadeMode.Stop;
            RuleFor(x => x.Quantity)
                .NotNull()
                .WithMessage("Quantity is required!")
                .Must(quantity => (int)quantity > 0)
                .WithMessage("Quantity must be positive!");
            RuleFor(x => x.OptionID)
                .NotNull()
                .WithMessage("Order has to be connected with an option!")
                .Must(x => context.Options.Any(o => o.ID == (int)x))
                .WithMessage("Option does not exist.")
                .Must(x=>context.Options.Any(o=>o.ID==(int)x && o.Available == true))
                .WithMessage("Option is not available at the moment.");
            RuleFor(x => x.UserID)
                .NotNull()
                .WithMessage("Order has to be connected with a user!")
                .Must(x => context.Users.Any(u => u.ID == (int)x))
                .WithMessage("User does not exist.");
        }
    }
}
