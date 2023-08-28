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
    public class EFCreateOptionCommand : EFUseCase, ICreateOptionCommand
    {
        private CreateOptionValidator _validator;
        public EFCreateOptionCommand(
                MiniactionContext context,
                CreateOptionValidator validator
            )
            : base(context)
        {
            _validator = validator;
        }
        public int ID => 7;
        public string Name => "Create an option";
        public string Description => "Creates an option.";
        public void Execute(CreateOptionDTO request)
        {
            _validator.ValidateAndThrow(request);
            Option option = new Option();
            if(request.Available.HasValue)
            {
                option.Available = (bool)request.Available;
            }
            option.Price = (decimal)request.Price;
            option.SerialID = (int)request.SerialID;
            option.FormatID = (int)request.FormatID;
            Context.Add(option);
            Context.SaveChanges();
        }
    }
}
