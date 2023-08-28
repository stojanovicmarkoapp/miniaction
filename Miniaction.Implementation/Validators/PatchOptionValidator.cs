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
    public class PatchOptionValidator : AbstractValidator<PatchOptionDTO>
    {
        public PatchOptionValidator(MiniactionContext context)
        {
            RuleLevelCascadeMode = CascadeMode.Stop;
            RuleFor(x => x.Price)
                .Must(price => (decimal)price > 0)
                .When(x => x.Price.HasValue)
                .WithMessage("Price must be either positive, or nothing if not modifying!");
        }
    }
}
