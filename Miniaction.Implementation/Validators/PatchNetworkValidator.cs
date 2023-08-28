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
    public class PatchNetworkValidator : AbstractValidator<PatchNetworkDTO>
    {
        public PatchNetworkValidator(MiniactionContext context)
        {
            RuleLevelCascadeMode = CascadeMode.Stop;
            RuleFor(x => x.Name)
                .Must((dto, name) => string.IsNullOrEmpty(name) || !context.Networks.Any(n => n.Name == name))
                .WithMessage("Network name has to be unique, or nothing if not modifying!");
        }
    }
}
