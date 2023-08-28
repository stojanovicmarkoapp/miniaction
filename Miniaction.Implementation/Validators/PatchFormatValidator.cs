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
    public class PatchFormatValidator : AbstractValidator<PatchFormatDTO>
    {
        public PatchFormatValidator(MiniactionContext context)
        {
            RuleLevelCascadeMode = CascadeMode.Stop;
            RuleFor(x => x.Name)
                .Must((dto, name) => string.IsNullOrEmpty(name) || !context.Formats.Any(f => f.Name == name))
                .WithMessage("Format name has to be unique, or nothing if not modifying!");
        }
    }
}
