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
    public class EFFindSerialQuery : IFindSerialQuery
    {
        private readonly MiniactionContext _context;
        public EFFindSerialQuery(MiniactionContext context)
        {
            _context = context;
        }
        public int ID => 34;

        public string Name => "Find a serial";

        public string Description => "Finds a serial.";

        public ReadSerialDTO Execute(int id)
        {
            Serial serial = _context.Serials
                              .Include(s=>s.PG)
                              .Include(s=>s.Trailer)
                              .Include(s=>s.Genre)
                              .Include(s=>s.Network)
                              .Include(s=>s.Options)
                                .ThenInclude(o=>o.Format)
                              .FirstOrDefault(s => s.ID == id);
            if (serial == null)
            {
                throw new Exception("Serial is not found.");
            }
            return new ReadSerialDTO
            {
                ID = serial.ID,
                Title = serial.Title,
                Features = serial.Features,
                Released = serial.Released,
                PG = new ReadPGDTONutshell
                {
                    ID = serial.PG.ID,
                    Name = serial.PG.Name,
                },
                TrailerName = serial.TrailerID.HasValue ? serial.Trailer.Name : null,
                Genre = new ReadGenreDTONutshell
                {
                    ID = serial.Genre.ID,
                    Name = serial.Genre.Name,
                },
                Network = new ReadNetworkDTONutshell
                {
                    ID = serial.Network.ID,
                    Name = serial.Network.Name,
                },
                Options = serial.Options.Select(o => new ReadOptionDTONutshell
                {
                    ID = o.ID,
                    FormatName = o.Format.Name
                }).ToList()
            };
        }
    }
}
