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
    public class PatchGenreValidator : AbstractValidator<PatchGenreDTO>
    {
        public PatchGenreValidator(MiniactionContext context)
        {
            RuleLevelCascadeMode = CascadeMode.Stop;
            RuleFor(x => x.Name)
                .Must((dto, name) => string.IsNullOrEmpty(name) || !context.Genres.Any(g => g.Name == name))
                .WithMessage("Genre name has to be unique, or nothing if not modifying!");
        }
    }
}
