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
    public class EFSearchFormatsQuery : ISearchFormatsQuery
    {
        private readonly MiniactionContext _context;
        public EFSearchFormatsQuery(MiniactionContext context)
        {
            _context = context;
        }
        public int ID => 16;

        public string Name => "Formats search";

        public string Description => "Searches formats.";

        public IEnumerable<ReadFormatDTO> Execute(FormatSearch search)
        {
            var formats = _context.Formats.AsQueryable();
            if (!string.IsNullOrEmpty(search.Name))
            {
                formats = formats.Where(f => f.Name.Contains(search.Name));
            }
            return formats.Select(f => new ReadFormatDTO
            {
                ID = f.ID,
                Name = f.Name
            }).ToList();
        }
    }
}
