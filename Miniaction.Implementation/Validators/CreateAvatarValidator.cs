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
    public class CreateAvatarValidator : AbstractValidator<CreateAvatarDTO>
    {
        public CreateAvatarValidator(MiniactionContext context)
        {
            RuleLevelCascadeMode = CascadeMode.Stop;
            RuleFor(x => x.UserID)
                .NotNull()
                .WithMessage("Avatar has to be connected with a user!")
                .Must(x => context.Users.Any(u => u.ID == (int)x))
                .WithMessage("User does not exist.")
                .Must(x => !context.Users.Any(u => u.ID == (int)x && u.AvatarID.HasValue))
                .WithMessage("User already has an avatar.");
            RuleFor(x => x.Avatar)
                .NotEmpty()
                .WithMessage("Avatar file is required!")
                .Must(avatar => FileHelpers.AvatarExtensionChecker(avatar))
                .WithMessage("Invalid avatar extension. Allowed extensions are .jpg, .jpeg, .png, and .webp.");
            RuleFor(x => x.Label)
                .NotEmpty()
                .WithMessage("Label is required!")
                .Must(label => Regex.IsMatch(label, @"^[a-zA-Z0-9_-]+$"))
                .WithMessage("Label has to consist only of letters, hyphens, underscores, and numbers!");
        }
    }
}
