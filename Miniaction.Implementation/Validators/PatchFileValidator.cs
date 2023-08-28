using FluentValidation;
using Miniaction.Application.UseCases.DTO;
using Miniaction.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Miniaction.Implementation.Validators
{
    public class PatchFileValidator : AbstractValidator<PatchFileDTO>
    {
        public PatchFileValidator(MiniactionContext context)
        {
            RuleLevelCascadeMode = CascadeMode.Stop;
            RuleFor(x => x.Label)
                .Must(label => string.IsNullOrEmpty(label) || Regex.IsMatch(label, @"^[a-zA-Z0-9_-]+$"))
                .WithMessage("Label has to consist only of letters, hyphens, underscores, and numbers, or nothing if not modifying!");
        }
    }
}
