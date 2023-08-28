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
    public class PatchReviewValidator : AbstractValidator<PatchReviewDTO>
    {
        public PatchReviewValidator(MiniactionContext context)
        {
            RuleLevelCascadeMode = CascadeMode.Stop;
            RuleFor(x => x.StarScore)
                .Must(x => !x.HasValue || context.Stars.Any(s => s.Score == (int)x))
                .WithMessage("Star score has to exist, or be nothing if not modifying.");
        }
    }
}
