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
    public class CreateGenreValidator : AbstractValidator<CreateGenreDTO>
    {
        public CreateGenreValidator(MiniactionContext context)
        {
            RuleLevelCascadeMode = CascadeMode.Stop;
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Genre name is required!")
                .Must(x => !context.Genres.Any(g => g.Name == x))
                .WithMessage("Genre name has to be unique!");
        }
    }
}
