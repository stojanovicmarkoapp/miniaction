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
using Microsoft.AspNetCore.Hosting;

namespace Miniaction.Implementation.UseCases.Commands
{
    public class EFCreateUserCommand : EFUseCase, ICreateUserCommand
    {
        private CreateUserValidator _validator;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public EFCreateUserCommand(
                MiniactionContext context,
                CreateUserValidator validator,
                IWebHostEnvironment hostingEnvironment
            )
            : base(context)
        {
            _validator = validator;
            _hostingEnvironment = hostingEnvironment;
        }
        public int ID => 9;
        public string Name => "Create a user";
        public string Description => "Creates a user.";
        public void Execute(CreateUserDTO request)
        {
            _validator.ValidateAndThrow(request);
            User user = new User();
            user.Username = request.Username;
            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.Sex = (char)request.Sex;
            user.EmailAddress = request.EmailAddress;
            user.HomeAddress = request.HomeAddress;
            //user.Password = HashHelpers.HashToSHA512(request.Password);
            user.Password = BCrypt.Net.BCrypt.HashPassword(request.Password);
            Context.Add(user);
            Context.SaveChanges();
            if (!string.IsNullOrEmpty(request.Avatar))
            {
                //string avatarsFolder = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).ToString(), "Miniaction.API\\WWWRoot\\Avatars");
                string avatarsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "Avatars");
                string fileExtension = FileHelpers.GetFileExtensionFromBase64File(request.Avatar);
                string fileName = FileHelpers.GenerateUniqueFileName(request.AvatarLabel, fileExtension);
                string filePath = Path.Combine(avatarsFolder, fileName);
                byte[] fileBytes = Convert.FromBase64String(request.Avatar.Split(";")[1].Split(",")[1]);
                System.IO.File.WriteAllBytes(filePath, fileBytes);
                Avatar avatar = new Avatar();
                avatar.Name = fileName;
                avatar.UserID = user.ID;
                Context.Add(avatar);
                Context.SaveChanges();
                user.AvatarID = avatar.ID;
                Context.SaveChanges();
            }
        }
    }
}
