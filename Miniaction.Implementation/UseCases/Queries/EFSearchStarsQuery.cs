using Miniaction.Application.UseCases.DTO;
using Miniaction.Application.UseCases.Queries.Searches;
using Miniaction.Application.UseCases.Queries;
using Miniaction.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miniaction.Implementation.UseCases.Queries
{
    public class EFSearchStarsQuery : ISearchStarsQuery
    {
        private readonly MiniactionContext _context;
        public EFSearchStarsQuery(MiniactionContext context)
        {
            _context = context;
        }
        public int ID => 26;

        public string Name => "Stars search";

        public string Description => "Searches stars.";

        public IEnumerable<ReadStarDTO> Execute(StarSearch search)
        {
            var stars = _context.Stars.AsQueryable();
            if (search.Score.HasValue)
            {
                stars = stars.Where(s => s.Score==(int)search.Score);
            }
            return stars.Select(s => new ReadStarDTO
            {
                ID = s.ID,
                Score = s.Score,
                Description = s.Description
            }).ToList();
        }
    }
}
