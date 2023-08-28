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
    public class EFCreateAvatarCommand : EFUseCase, ICreateAvatarCommand
    {
        private CreateAvatarValidator _validator;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public EFCreateAvatarCommand(
                MiniactionContext context,
                CreateAvatarValidator validator,
                IWebHostEnvironment hostingEnvironment)
            : base(context)
        {
            _validator = validator;
            _hostingEnvironment = hostingEnvironment;
        }
        public int ID => 10;
        public string Name => "Create an avatar";
        public string Description => "Creates an avatar.";
        public void Execute(CreateAvatarDTO request)
        {
            _validator.ValidateAndThrow(request);
            //string avatarsFolder = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).ToString(), "Miniaction.API\\WWWRoot\\Avatars");
            string avatarsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "Avatars");
            string fileExtension = FileHelpers.GetFileExtensionFromBase64File(request.Avatar);
            string fileName = FileHelpers.GenerateUniqueFileName(request.Label, fileExtension);
            string filePath = Path.Combine(avatarsFolder, fileName);
            byte[] fileBytes = Convert.FromBase64String(request.Avatar.Split(";")[1].Split(",")[1]);
            System.IO.File.WriteAllBytes(filePath, fileBytes);
            Avatar avatar = new Avatar();
            avatar.Name = fileName;
            avatar.UserID = (int)request.UserID;
            Context.Add(avatar);
            Context.SaveChanges();
            var user = Context.Users.FirstOrDefault(u => u.ID == avatar.UserID);
            user.AvatarID = avatar.ID;
            Context.SaveChanges();
        }
    }
}
