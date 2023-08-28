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
    public class EFCreateTrailerCommand : EFUseCase, ICreateTrailerCommand
    {
        private CreateTrailerValidator _validator;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public EFCreateTrailerCommand(
                MiniactionContext context,
                CreateTrailerValidator validator,
                IWebHostEnvironment hostingEnvironment
            )
            : base(context)
        {
            _validator = validator;
            _hostingEnvironment = hostingEnvironment;
        }
        public int ID => 6;
        public string Name => "Create a trailer";
        public string Description => "Creates a trailer.";
        public void Execute(CreateTrailerDTO request)
        {
            _validator.ValidateAndThrow(request);
            //string trailersFolder = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).ToString(), "Miniaction.API\\WWWRoot\\Trailers");
            string trailersFolder = Path.Combine(_hostingEnvironment.WebRootPath, "Trailers");
            string fileExtension = FileHelpers.GetFileExtensionFromBase64File(request.Trailer);
            string fileName = FileHelpers.GenerateUniqueFileName(request.Label, fileExtension);
            string filePath = Path.Combine(trailersFolder, fileName);
            byte[] fileBytes = Convert.FromBase64String(request.Trailer.Split(";")[1].Split(",")[1]);
            System.IO.File.WriteAllBytes(filePath, fileBytes);
            Trailer trailer = new Trailer();
            trailer.Name = fileName;
            trailer.SerialID = (int)request.SerialID;
            Context.Add(trailer);
            Context.SaveChanges();
            var serial = Context.Serials.FirstOrDefault(s => s.ID == trailer.SerialID);
            serial.TrailerID = trailer.ID;
            Context.SaveChanges();
        }
    }
}
