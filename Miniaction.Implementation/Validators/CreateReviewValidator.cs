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
    public class CreateReviewValidator : AbstractValidator<CreateReviewDTO>
    {
        public CreateReviewValidator(MiniactionContext context)
        {
            RuleLevelCascadeMode = CascadeMode.Stop;
            RuleFor(x => x.Comment)
                .NotEmpty()
                .WithMessage("Comment is required!");
            RuleFor(x => x.OptionID)
                .NotNull()
                .WithMessage("Review has to be connected with an option!")
                .Must(x => context.Options.Any(o => o.ID == (int)x))
                .WithMessage("Option does not exist.");
            RuleFor(x => x.UserID)
                .NotNull()
                .WithMessage("Review has to be connected with a user!")
                .Must(x => context.Users.Any(u => u.ID == (int)x))
                .WithMessage("User does not exist.");
            RuleFor(x => x.StarID)
                .NotNull()
                .WithMessage("Review has to be connected with a star!")
                .Must(x => context.Stars.Any(s => s.ID == (int)x))
                .WithMessage("Star does not exist.");
            RuleFor(dto => new { dto.UserID, dto.OptionID })
                .Must(dto => context.Orders.Any(o => o.UserID == (int)dto.UserID && o.OptionID == (int)dto.OptionID && o.Paid == true))
                .WithMessage("User has not paid for any purchase of this option.")
                .Must(dto => !context.Reviews.Any(r => r.UserID == (int)dto.UserID && r.OptionID == (int)dto.OptionID))
                .WithMessage("User has already made a review for this option.");
        }
    }
}
