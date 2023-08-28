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
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;

namespace Miniaction.Implementation.UseCases.Queries
{
    public class EFSearchSerialsQuery : ISearchSerialsQuery
    {
        private readonly MiniactionContext _context;
        public EFSearchSerialsQuery(MiniactionContext context)
        {
            _context = context;
        }
        public int ID => 19;

        public string Name => "Serials search";

        public string Description => "Searches serials.";

        public IEnumerable<ReadSerialDTO> Execute(SerialSearch search)
        {
            var serials = _context.Serials.Include(s => s.PG)
                                          .Include(s => s.Genre)
                                          .Include(s => s.Network)
                                          .Include(s=>s.Trailer)
                                          .Include(s => s.Options)
                                            .ThenInclude(f=>f.Format).AsQueryable();
            if (!string.IsNullOrEmpty(search.Title))
            {
                serials = serials.Where(s => s.Title.Contains(search.Title));
            }
            if (search.Released.HasValue)
            {
                serials = serials.Where(s => s.Released == (int)search.Released);
            }
            if (search.PGID.HasValue)
            {
                serials = serials.Where(s => s.PGID == (int)search.PGID);
            }
            if (!string.IsNullOrEmpty(search.PGName))
            {
                serials = serials.Where(s => s.PG.Name.Contains(search.PGName));
            }
            if (search.GenreID.HasValue)
            {
                serials = serials.Where(s => s.GenreID == (int)search.GenreID);
            }
            if (!string.IsNullOrEmpty(search.GenreName))
            {
                serials = serials.Where(s => s.Genre.Name.Contains(search.GenreName));
            }
            if (search.NetworkID.HasValue)
            {
                serials = serials.Where(s => s.NetworkID == (int)search.NetworkID);
            }
            if (!string.IsNullOrEmpty(search.NetworkName))
            {
                serials = serials.Where(s => s.Network.Name.Contains(search.NetworkName));
            }
            return serials.Select(s => new ReadSerialDTO
            {
                ID = s.ID,
                Title = s.Title,
                Features = s.Features,
                Released = s.Released,
                PG = new ReadPGDTONutshell
                {
                    ID = s.PG.ID,
                    Name = s.PG.Name,
                },
                TrailerName = s.TrailerID.HasValue ? s.Trailer.Name : null,
                Genre = new ReadGenreDTONutshell
                {
                    ID = s.Genre.ID,
                    Name = s.Genre.Name,
                },
                Network = new ReadNetworkDTONutshell
                {
                    ID = s.Network.ID,
                    Name = s.Network.Name,
                },
                Options = s.Options.Select(o => new ReadOptionDTONutshell
                {
                    ID = o.ID,
                    FormatName = o.Format.Name
                }).ToList()
            }).ToList();
        }
    }
}
