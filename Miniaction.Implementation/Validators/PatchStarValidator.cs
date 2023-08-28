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
    public class PatchStarValidator : AbstractValidator<PatchStarDTO>
    {
        public PatchStarValidator(MiniactionContext context)
        {
            RuleLevelCascadeMode = CascadeMode.Stop;
            RuleFor(x => x.Score)
                .Must((dto, score) => !score.HasValue || !context.Stars.Any(s => s.Score == (int)score))
                .WithMessage("Star score has to be unique, or nothing if not modifying!");
        }
    }
}
