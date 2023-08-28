using FluentValidation;
using Miniaction.Implementation.Helpers;
using Miniaction.Application.UseCases.Commands;
using Miniaction.Application.UseCases.DTO;
using Miniaction.DataAccess;
using Miniaction.Domain.Entities;
using Miniaction.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miniaction.Implementation.UseCases.Commands
{
    public class EFCreateRoleCommand : EFUseCase, ICreateRoleCommand
    {
        private CreateRoleValidator _validator;
        public EFCreateRoleCommand(
                MiniactionContext context,
                CreateRoleValidator validator
            )
            : base(context)
        {
            _validator = validator;
        }
        public int ID => 8;
        public string Name => "Create a role";
        public string Description => "Creates a role.";
        public void Execute(CreateRoleDTO request)
        {
            _validator.ValidateAndThrow(request);
            Role role = new Role();
            role.Name = request.Name;
            Context.Add(role);
            Context.SaveChanges();
            if(request.UseCaseIDs != null)
            {
                 role.Grants = request.UseCaseIDs.Select(u =>
                 {
                     return new Grant
                     {
                          RoleID = role.ID,
                          UseCaseID = u
                     };
                 }).ToList();
                 Context.SaveChanges();
            }
        }
    }
}
