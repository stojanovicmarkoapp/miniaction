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
    public class EFCreateNetworkCommand : EFUseCase, ICreateNetworkCommand
    {
        private CreateNetworkValidator _validator;
        public EFCreateNetworkCommand(
                MiniactionContext context,
                CreateNetworkValidator validator
            )
            :base(context)
        {
            _validator = validator;
        }
        public int ID => 3;
        public string Name => "Create a network";
        public string Description => "Creates a network.";
        public void Execute(CreateNetworkDTO request)
        {
            _validator.ValidateAndThrow(request);
            Network network = new Network();
            network.Name = request.Name;
            Context.Add(network);
            Context.SaveChanges();
        }
    }
}
