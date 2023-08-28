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
    public class CreateNetworkValidator : AbstractValidator<CreateNetworkDTO>
    {
        public CreateNetworkValidator(MiniactionContext context)
        {
            RuleLevelCascadeMode = CascadeMode.Stop;
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Network name is required!")
                .Must(x=>!context.Networks.Any(n => n.Name == x))
                .WithMessage("Network name has to be unique!");
        }
    }
}
