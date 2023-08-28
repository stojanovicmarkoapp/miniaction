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
    public class CreateTrailerValidator : AbstractValidator<CreateTrailerDTO>
    {
        public CreateTrailerValidator(MiniactionContext context)
        {
            RuleLevelCascadeMode = CascadeMode.Stop;
            RuleFor(x => x.SerialID)
                .NotNull()
                .WithMessage("Trailer has to be connected with a serial!")
                .Must(x => context.Serials.Any(s => s.ID == (int)x))
                .WithMessage("Serial does not exist.")
                .Must(x => !context.Serials.Any(s => s.ID == (int)x && s.TrailerID.HasValue))
                .WithMessage("Serial already has a trailer.");
            RuleFor(x => x.Trailer)
                .NotEmpty()
                .WithMessage("Trailer file is required!")
                .Must(trailer => FileHelpers.TrailerExtensionChecker(trailer))
                .WithMessage("Invalid trailer extension. Allowed extensions are .mp4, .m4v, .mkv, .avi, and .wmv.");
            RuleFor(x => x.Label)
                .NotEmpty()
                .WithMessage("Label is required!")
                .Must(label => Regex.IsMatch(label, @"^[a-zA-Z0-9_-]+$"))
                .WithMessage("Label has to consist only of letters, hyphens, underscores, and numbers!");
        }
    }
}
