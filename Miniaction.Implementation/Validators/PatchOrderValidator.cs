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
    public class PatchOrderValidator : AbstractValidator<PatchOrderDTO>
    {
        public PatchOrderValidator(MiniactionContext context)
        {
            RuleLevelCascadeMode = CascadeMode.Stop;
            RuleFor(x => x.Paid)
                .NotNull()
                .WithMessage("You have to mark order as either paid, or unpaid!");
            RuleFor(x => x.Quantity)
                .Must(quantity => (int)quantity > 0)
                .When(x => x.Quantity.HasValue)
                .WithMessage("Quantity must be either positive, or nothing if not modifying!");
            RuleFor(x => x.Price)
                .Must(price => (decimal)price > 0)
                .When(x => x.Price.HasValue)
                .WithMessage("Price must be either positive, or nothing if not modifying!");
        }
    }
}
