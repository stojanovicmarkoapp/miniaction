using FluentValidation;
using Miniaction.Implementation.Helpers;
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
    public class CreateSerialValidator : AbstractValidator<CreateSerialDTO>
    {
        public CreateSerialValidator(MiniactionContext context)
        {
            RuleLevelCascadeMode = CascadeMode.Stop;
            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage("Title is required!");
            RuleFor(x => x.Features)
                .NotEmpty()
                .WithMessage("Features are required!");
            RuleFor(x => x.Released)
                .NotNull()
                .WithMessage("Release year is required!");
            RuleFor(x => x.PGID)
                .NotNull()
                .WithMessage("Serial has to be connected with a parental guideline!")
                .Must(x => context.PGs.Any(p => p.ID == (int)x))
                .WithMessage("Parental guideline does not exist.");
            RuleFor(x => x.GenreID)
                .NotNull()
                .WithMessage("Serial has to be connected with a genre!")
                .Must(x => context.Genres.Any(g => g.ID == (int)x))
                .WithMessage("Genre does not exist.");
            RuleFor(x => x.NetworkID)
                .NotNull()
                .WithMessage("Serial has to be connected with a network!")
                .Must(x => context.Networks.Any(n => n.ID == (int)x))
                .WithMessage("Network does not exist.");
            RuleFor(x => x.Trailer)
                .NotEmpty()
                .When(dto => !string.IsNullOrEmpty(dto.TrailerLabel))
                .WithMessage("Trailer file is required when trailer label is provided!")
                .Must(trailer => FileHelpers.TrailerExtensionChecker(trailer))
                .When(dto => !string.IsNullOrEmpty(dto.TrailerLabel))
                .WithMessage("Invalid trailer extension. Allowed extensions are .mp4, .m4v, .mkv, .avi, and .wmv.");
            RuleFor(x => x.TrailerLabel)
                .NotEmpty()
                .When(dto => !string.IsNullOrEmpty(dto.Trailer))
                .WithMessage("Label is required when trailer is provided!")
                .Must(label => Regex.IsMatch(label, @"^[a-zA-Z0-9_-]+$"))
                .When(dto => !string.IsNullOrEmpty(dto.Trailer))
                .WithMessage("Label has to consist only of letters, hyphens, underscores, and numbers!");
        }
    }
}
