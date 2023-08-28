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
    public class EFCreateStarCommand : EFUseCase, ICreateStarCommand
    {
        private CreateStarValidator _validator;
        public EFCreateStarCommand(
                MiniactionContext context,
                CreateStarValidator validator
            )
            : base(context)
        {
            _validator = validator;
        }
        public int ID => 12;
        public string Name => "Create a star";
        public string Description => "Creates a star.";
        public void Execute(CreateStarDTO request)
        {
            _validator.ValidateAndThrow(request);
            Star star = new Star();
            star.Score = (int)request.Score;
            star.Description = request.Description;
            Context.Add(star);
            Context.SaveChanges();
        }
    }
}
