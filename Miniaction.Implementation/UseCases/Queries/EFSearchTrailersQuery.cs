using Miniaction.Application.UseCases.DTO;
using Miniaction.Application.UseCases.Queries.Searches;
using Miniaction.Application.UseCases.Queries;
using Miniaction.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Miniaction.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Miniaction.Implementation.UseCases.Queries
{
    public class EFSearchTrailersQuery : ISearchTrailersQuery
    {
        private readonly MiniactionContext _context;
        public EFSearchTrailersQuery(MiniactionContext context)
        {
            _context = context;
        }
        public int ID => 20;

        public string Name => "Trailers search";

        public string Description => "Searches trailers.";

        public IEnumerable<ReadTrailerDTO> Execute(TrailerSearch search)
        {
            var trailers = _context.Trailers.Include(t=>t.Serial).AsQueryable();
            if (!string.IsNullOrEmpty(search.Name))
            {
                trailers = trailers.Where(t => t.Name.Contains(search.Name));
            }
            if (!string.IsNullOrEmpty(search.SerialTitle))
            {
                trailers = trailers.Where(t => t.Serial.Title.Contains(search.SerialTitle));
            }
            if (search.SerialID.HasValue)
            {
                trailers = trailers.Where(t => t.SerialID == (int)search.SerialID);
            }
            return trailers.Select(t => new ReadTrailerDTO
            {
                ID = t.ID,
                Name = t.Name,
                Serial = new ReadSerialDTONutshell
                {
                    ID = t.Serial.ID,
                    Title = t.Serial.Title
                }
            }).ToList();
        }
    }
}
