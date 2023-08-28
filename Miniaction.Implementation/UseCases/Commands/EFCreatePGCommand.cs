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
    public class EFCreatePGCommand : EFUseCase, ICreatePGCommand
    {
        private CreatePGValidator _validator;
        public EFCreatePGCommand(
                MiniactionContext context,
                CreatePGValidator validator
            )
            : base(context)
        {
            _validator = validator;
        }
        public int ID => 4;
        public string Name => "Create a parental guideline";
        public string Description => "Creates a parental guideline.";
        public void Execute(CreatePGDTO request)
        {
            _validator.ValidateAndThrow(request);
            PG pg = new PG();
            pg.Name = request.Name;
            pg.Description = request.Description;
            Context.Add(pg);
            Context.SaveChanges();
        }
    }
}
