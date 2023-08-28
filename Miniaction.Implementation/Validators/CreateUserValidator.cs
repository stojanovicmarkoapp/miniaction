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
    public class CreateUserValidator : AbstractValidator<CreateUserDTO>
    {
        public CreateUserValidator(MiniactionContext context)
        {
            RuleLevelCascadeMode = CascadeMode.Stop;
            RuleFor(x => x.Username)
                .NotEmpty()
                .WithMessage("Username is required!")
                .Must(x => !context.Users.Any(u => u.Username == x))
                .WithMessage("Username has to be unique!");
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage("First name is required!");
            RuleFor(x => x.LastName)
                .NotEmpty()
                .WithMessage("Last name is required!");
            RuleFor(x => x.Sex)
                .NotNull()
                .WithMessage("Sex is required!")
                .Must(sex => (char)sex == 'M' || (char)sex == 'F')
                .WithMessage("Sex must be either male or female.");
            RuleFor(x => x.EmailAddress)
                .NotEmpty()
                .WithMessage("Email address is required!")
                .EmailAddress()
                .WithMessage("Invalid email address.")
                .Must(x => !context.Users.Any(u => u.EmailAddress == x))
                .WithMessage("Email address has to be unique!");
            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Password is required!")
                .Matches("^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z]).{4,}$")
                .WithMessage("Password must have at least one number, one lowercase letter, one uppercase letter, and be at least 4 characters long.");
            RuleFor(x => x.Avatar)
                .NotEmpty()
                .When(dto => !string.IsNullOrEmpty(dto.AvatarLabel))
                .WithMessage("Avatar file is required when avatar label is provided!")
                .Must(avatar => FileHelpers.AvatarExtensionChecker(avatar))
                .When(dto => !string.IsNullOrEmpty(dto.AvatarLabel))
                .WithMessage("Invalid avatar extension. Allowed extensions are .jpg, .jpeg, .png, and .webp.");
            RuleFor(x => x.AvatarLabel)
                .NotEmpty()
                .When(dto => !string.IsNullOrEmpty(dto.Avatar))
                .WithMessage("Label is required when avatar is provided!")
                .Must(label => Regex.IsMatch(label, @"^[a-zA-Z0-9_-]+$"))
                .When(dto => !string.IsNullOrEmpty(dto.Avatar))
                .WithMessage("Label has to consist only of letters, hyphens, underscores, and numbers!");
        }
    }
}
