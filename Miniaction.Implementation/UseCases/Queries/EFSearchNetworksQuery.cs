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
    public class EFSearchNetworksQuery : ISearchNetworksQuery
    {
        private readonly MiniactionContext _context;
        public EFSearchNetworksQuery(MiniactionContext context)
        {
            _context = context;
        }
        public int ID => 17;

        public string Name => "Networks search";

        public string Description => "Searches networks.";

        public IEnumerable<ReadNetworkDTO> Execute(NetworkSearch search)
        {
            var networks = _context.Networks.AsQueryable();
            if (!string.IsNullOrEmpty(search.Name))
            {
                networks = networks.Where(n => n.Name.Contains(search.Name));
            }
            return networks.Select(n => new ReadNetworkDTO
            {
                ID = n.ID,
                Name = n.Name
            }).ToList();
        }
    }
}
