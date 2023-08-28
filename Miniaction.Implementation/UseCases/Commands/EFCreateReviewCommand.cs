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
    public class EFCreateReviewCommand : EFUseCase, ICreateReviewCommand
    {
        private CreateReviewValidator _validator;
        public EFCreateReviewCommand(
                MiniactionContext context,
                CreateReviewValidator validator
            )
            : base(context)
        {
            _validator = validator;
        }
        public int ID => 13;
        public string Name => "Create a review";
        public string Description => "Creates a review.";
        public void Execute(CreateReviewDTO request)
        {
            _validator.ValidateAndThrow(request);
            Review review = new Review();
            review.ModifiedAt = DateTime.UtcNow;
            review.Comment = request.Comment;
            review.OptionID = (int)request.OptionID;
            review.UserID = (int)request.UserID;
            review.StarID = (int)request.StarID;
            Context.Add(review);
            Context.SaveChanges();
        }
    }
}
