using FluentValidation;
using Miniaction.Application.UseCases.Commands;
using Miniaction.Application.UseCases.DTO;
using Miniaction.DataAccess;
using Miniaction.Domain.Entities;
using Miniaction.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miniaction.Implementation.UseCases.Commands
{
    public class EFCreateFormatCommand : EFUseCase, ICreateFormatCommand
    {
        private CreateFormatValidator _validator;
        public EFCreateFormatCommand(
                MiniactionContext context,
                CreateFormatValidator validator
            )
            : base(context)
        {
            _validator = validator;
        }
        public int ID => 2;
        public string Name => "Create a format";
        public string Description => "Creates a format.";
        public void Execute(CreateFormatDTO request)
        {
            _validator.ValidateAndThrow(request);
            Format format = new Format();
            format.Name = request.Name;
            Context.Add(format);
            Context.SaveChanges();
        }
    }
}
