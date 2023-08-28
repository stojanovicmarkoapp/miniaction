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
    public class PatchSerialValidator : AbstractValidator<PatchSerialDTO>
    {
        public PatchSerialValidator(MiniactionContext context)
        {
            RuleLevelCascadeMode = CascadeMode.Stop;
            RuleFor(x => x.Released)
                .Must(released => (int)released > 0)
                .When(x => x.Released.HasValue)
                .WithMessage("Release year must be either positive, or nothing if not modifying!");
            RuleFor(x => x.PGID)
                .Must(x => !x.HasValue || context.PGs.Any(p => p.ID == (int)x))
                .WithMessage("Parental guideline has to exist, or be nothing if not modifying.");
            RuleFor(x => x.GenreID)
                .Must(x => !x.HasValue || context.Genres.Any(g => g.ID == (int)x))
                .WithMessage("Genre has to exist, or be nothing if not modifying.");
            RuleFor(x => x.NetworkID)
                .Must(x => !x.HasValue || context.Networks.Any(n => n.ID == (int)x))
                .WithMessage("Network has to exist, or be nothing if not modifying.");
        }
    }
}
