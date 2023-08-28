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
    public class CreateFormatValidator : AbstractValidator<CreateFormatDTO>
    {
        public CreateFormatValidator(MiniactionContext context)
        {
            RuleLevelCascadeMode = CascadeMode.Stop;
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Format name is required!")
                .Must(x => !context.Formats.Any(f => f.Name == x))
                .WithMessage("Format name has to be unique!");
        }
    }
}
