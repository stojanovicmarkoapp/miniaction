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
    public class CreateGrantValidator : AbstractValidator<CreateGrantDTO>
    {
        public CreateGrantValidator(MiniactionContext context)
        {
            RuleLevelCascadeMode = CascadeMode.Stop;
            RuleFor(x => x.RoleID)
                .NotNull()
                .WithMessage("Grant has to be connected with a role!")
                .Must(x => context.Roles.Any(r => r.ID == (int)x))
                .WithMessage("Role does not exist.");
        }
    }
}
