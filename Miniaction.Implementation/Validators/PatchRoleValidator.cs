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
    public class PatchRoleValidator : AbstractValidator<PatchRoleDTO>
    {
        public PatchRoleValidator(MiniactionContext context)
        {
            RuleLevelCascadeMode = CascadeMode.Stop;
            RuleFor(x => x.Name)
                .Must((dto, name) => string.IsNullOrEmpty(name) || !context.Roles.Any(r => r.Name == name))
                .WithMessage("Role name has to be unique, or nothing if not modifying!");
        }
    }
}
