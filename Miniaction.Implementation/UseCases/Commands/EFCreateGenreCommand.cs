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
    public class EFCreateGenreCommand : EFUseCase, ICreateGenreCommand
    {
        private CreateGenreValidator _validator;
        public EFCreateGenreCommand(
                MiniactionContext context,
                CreateGenreValidator validator
            )
            : base(context)
        {
            _validator = validator;
        }
        public int ID => 1;
        public string Name => "Create a genre";
        public string Description => "Creates a genre.";
        public void Execute(CreateGenreDTO request)
        {
            _validator.ValidateAndThrow(request);
            Genre genre = new Genre();
            genre.Name = request.Name;
            Context.Add(genre);
            Context.SaveChanges();
        }
    }
}
