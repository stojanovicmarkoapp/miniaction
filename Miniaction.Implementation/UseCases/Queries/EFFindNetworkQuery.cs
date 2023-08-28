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
    public class EFFindNetworkQuery : IFindNetworkQuery
    {
        private readonly MiniactionContext _context;
        public EFFindNetworkQuery(MiniactionContext context)
        {
            _context = context;
        }
        public int ID => 32;

        public string Name => "Find a network";

        public string Description => "Finds a network.";

        public ReadNetworkDTO Execute(int id)
        {
            Network network = _context.Networks
                              .FirstOrDefault(n => n.ID == id);
            if(network == null)
            {
                throw new Exception("Network is not found.");
            }
            return new ReadNetworkDTO
            {
                ID = network.ID,
                Name = network.Name
            };
        }
    }
}
