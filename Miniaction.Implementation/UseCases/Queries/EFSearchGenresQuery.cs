using Miniaction.Application.UseCases.DTO;
using Miniaction.Application.UseCases.Queries;
using Miniaction.Application.UseCases.Queries.Searches;
using Miniaction.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miniaction.Implementation.UseCases.Queries
{
    public class EFSearchGenresQuery : ISearchGenresQuery
    {
        private readonly MiniactionContext _context;
        public EFSearchGenresQuery(MiniactionContext context)
        {
            _context = context;
        }
        public int ID => 15;

        public string Name => "Genres search";

        public string Description => "Searches genres.";

        public IEnumerable<ReadGenreDTO> Execute(GenreSearch search)
        {
            var genres = _context.Genres.AsQueryable();
            if (!string.IsNullOrEmpty(search.Name))
            {
                genres = genres.Where(g => g.Name.Contains(search.Name));
            }
            return genres.Select(g => new ReadGenreDTO
            {
                ID = g.ID,
                Name = g.Name
            }).ToList();
        }
    }
}
