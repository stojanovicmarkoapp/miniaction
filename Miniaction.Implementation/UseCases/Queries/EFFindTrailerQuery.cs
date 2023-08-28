using Microsoft.EntityFrameworkCore;
using Miniaction.Application.UseCases.DTO;
using Miniaction.Application.UseCases.Queries;
using Miniaction.DataAccess;
using Miniaction.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miniaction.Implementation.UseCases.Queries
{
    public class EFFindTrailerQuery : IFindTrailerQuery
    {
        private readonly MiniactionContext _context;
        public EFFindTrailerQuery(MiniactionContext context)
        {
            _context = context;
        }
        public int ID => 35;

        public string Name => "Find a trailer";

        public string Description => "Finds a trailer.";

        public ReadTrailerDTO Execute(int id)
        {
            Trailer trailer = _context.Trailers
                              .Include(t=>t.Serial)
                              .FirstOrDefault(t => t.ID == id);
            if (trailer == null)
            {
                throw new Exception("Trailer is not found.");
            }
            return new ReadTrailerDTO
            {
                ID = trailer.ID,
                Name = trailer.Name,
                Serial = new ReadSerialDTONutshell
                {
                    ID = trailer.Serial.ID,
                    Title = trailer.Serial.Title
                }
            };
        }
    }
}
