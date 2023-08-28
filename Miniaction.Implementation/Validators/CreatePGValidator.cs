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
    public class CreatePGValidator : AbstractValidator<CreatePGDTO>
    {
        public CreatePGValidator(MiniactionContext context)
        {
            RuleLevelCascadeMode = CascadeMode.Stop;
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Parental guideline name is required!")
                .Must(x => !context.PGs.Any(p => p.Name == x))
                .WithMessage("Parental guideline name has to be unique!");
            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("Parental guideline description is required!");
        }
    }
}
