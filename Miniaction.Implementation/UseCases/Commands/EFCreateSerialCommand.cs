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
    public class EFCreateSerialCommand : EFUseCase, ICreateSerialCommand
    {
        private CreateSerialValidator _validator;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public EFCreateSerialCommand(
                MiniactionContext context,
                CreateSerialValidator validator,
                IWebHostEnvironment hostingEnvironment
            )
            : base(context)
        {
            _validator = validator;
            _hostingEnvironment = hostingEnvironment;
        }
        public int ID => 5;
        public string Name => "Create a serial";
        public string Description => "Creates a serial.";
        public void Execute(CreateSerialDTO request)
        {
            _validator.ValidateAndThrow(request);
            Serial serial = new Serial();
            serial.Title = request.Title;
            serial.Features = request.Features;
            serial.Released = (int)request.Released;
            serial.PGID = (int)request.PGID;
            serial.GenreID = (int)request.GenreID;
            serial.NetworkID = (int)request.NetworkID;
            Context.Add(serial);
            Context.SaveChanges();
            if(!string.IsNullOrEmpty(request.Trailer))
            {
                //string trailersFolder = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).ToString(), "Miniaction.API\\WWWRoot\\Trailers");
                string trailersFolder = Path.Combine(_hostingEnvironment.WebRootPath, "Trailers");
                string fileExtension = FileHelpers.GetFileExtensionFromBase64File(request.Trailer);
                string fileName = FileHelpers.GenerateUniqueFileName(request.TrailerLabel, fileExtension);
                string filePath = Path.Combine(trailersFolder, fileName);
                byte[] fileBytes = Convert.FromBase64String(request.Trailer.Split(";")[1].Split(",")[1]);
                System.IO.File.WriteAllBytes(filePath, fileBytes);
                Trailer trailer = new Trailer();
                trailer.Name = fileName;
                trailer.SerialID = serial.ID;
                Context.Add(trailer);
                Context.SaveChanges();
                serial.TrailerID = trailer.ID;
                Context.SaveChanges();
            }
        }
    }
}
