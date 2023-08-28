using FluentValidation;
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
    public class PatchUserValidator : AbstractValidator<PatchUserDTO>
    {
        public PatchUserValidator(MiniactionContext context)
        {
            RuleLevelCascadeMode = CascadeMode.Stop;
            RuleFor(x => x.Username)
                .Must((dto, username) => string.IsNullOrEmpty(username) || !context.Users.Any(u => u.Username == username))
                .WithMessage("Username has to be unique, or nothing if not modifying!");
            RuleFor(x => x.Sex)
                .Must(x => !x.HasValue || (char)x == 'M' || (char)x == 'F')
                .WithMessage("Sex has to be male, female, or nothing if not modifying!");
            RuleFor(x => x.EmailAddress)
                .EmailAddress()
                .When(x=>!string.IsNullOrEmpty(x.EmailAddress))
                .WithMessage("Invalid email address.")
                .Must(x => string.IsNullOrEmpty(x) || !context.Users.Any(u => u.EmailAddress == x))
                .WithMessage("Email address has to be unique, or nothing if not modifying!");
            RuleFor(x => x.Password)
                .Must(password => string.IsNullOrEmpty(password) || Regex.IsMatch(password, "^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z]).{4,}$"))
                .WithMessage("Password has to be have at least one number, one lowercase letter, one uppercase letter, and be at least 4 characters long, or be nothing if not modifying.");
            RuleFor(x => x.RoleID)
                .Must(x => !x.HasValue || context.Roles.Any(r => r.ID == (int)x))
                .WithMessage("Role has to exist, or to be nothing if not modifying!");
        }
    }
}
