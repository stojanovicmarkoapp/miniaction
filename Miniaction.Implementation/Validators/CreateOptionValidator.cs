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
    public class CreateOptionValidator : AbstractValidator<CreateOptionDTO>
    {
        public CreateOptionValidator(MiniactionContext context)
        {
            RuleLevelCascadeMode = CascadeMode.Stop;
            RuleFor(x => x.Price)
                .NotNull()
                .WithMessage("Price is required!")
                .Must(price => (decimal)price > 0)
                .WithMessage("Price must be positive!");
            RuleFor(x => x.SerialID)
                .NotNull()
                .WithMessage("Option has to be connected with a serial!")
                .Must(x => context.Serials.Any(s => s.ID == (int)x))
                .WithMessage("Serial does not exist.");
            RuleFor(x => x.FormatID)
                .NotNull()
                .WithMessage("Option has to be connected with a format!")
                .Must(x => context.Formats.Any(f => f.ID == (int)x))
                .WithMessage("Format does not exist.");
            RuleFor(dto => new { dto.SerialID, dto.FormatID })
                .Must(dto => !context.Options.Any(o => o.SerialID == (int)dto.SerialID && o.FormatID == (int)dto.FormatID))
                .WithMessage("Option with this serial and this format already exists!");
        }
    }
}
