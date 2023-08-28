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
    public class EFSearchPGsQuery : ISearchPGsQuery
    {
        private readonly MiniactionContext _context;
        public EFSearchPGsQuery(MiniactionContext context)
        {
            _context = context;
        }
        public int ID => 18;

        public string Name => "Parental guidelines search";

        public string Description => "Searches parental guidelines.";

        public IEnumerable<ReadPGDTO> Execute(PGSearch search)
        {
            var pgs = _context.PGs.AsQueryable();
            if (!string.IsNullOrEmpty(search.Name))
            {
                pgs = pgs.Where(p => p.Name.Contains(search.Name));
            }
            return pgs.Select(p => new ReadPGDTO
            {
                ID = p.ID,
                Name = p.Name,
                Description = p.Description
            }).ToList();
        }
    }
}
