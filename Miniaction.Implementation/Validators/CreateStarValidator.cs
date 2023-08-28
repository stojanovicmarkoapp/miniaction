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
    public class CreateStarValidator : AbstractValidator<CreateStarDTO>
    {
        public CreateStarValidator(MiniactionContext context)
        {
            RuleLevelCascadeMode = CascadeMode.Stop;
            RuleFor(x => x.Score)
                .NotNull()
                .WithMessage("Star score is required!")
                .Must(x => !context.Stars.Any(s => s.Score == (int)x))
                .WithMessage("Star score has to be unique!");
            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("Star description is required!");
        }
    }
}
