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
    public class PatchPGValidator : AbstractValidator<PatchPGDTO>
    {
        public PatchPGValidator(MiniactionContext context)
        {
            RuleLevelCascadeMode = CascadeMode.Stop;
            RuleFor(x => x.Name)
                .Must((dto, name) => string.IsNullOrEmpty(name) || !context.PGs.Any(p => p.Name == name))
                .WithMessage("Parental guideline name has to be unique or nothing if not modifying!");
        }
    }
}
