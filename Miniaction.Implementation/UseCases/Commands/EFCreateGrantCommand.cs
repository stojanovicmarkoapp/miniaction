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
    public class EFCreateGrantCommand : EFUseCase, ICreateGrantCommand
    {
        private CreateGrantValidator _validator;
        public EFCreateGrantCommand(
                MiniactionContext context,
                CreateGrantValidator validator
            )
            : base(context)
        {
            _validator = validator;
        }
        public int ID => 14;
        public string Name => "Create a grant";
        public string Description => "Creates a grant.";
        public void Execute(CreateGrantDTO request)
        {
            _validator.ValidateAndThrow(request);
            Grant grant = new Grant();
            grant.RoleID = request.RoleID;
            grant.UseCaseID = request.UseCaseID;
            Context.Add(grant);
            Context.SaveChanges();
        }
    }
}
