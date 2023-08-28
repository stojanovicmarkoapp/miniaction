using Miniaction.Application.UseCases.DTO;
using Miniaction.Application.UseCases.Queries;
using Miniaction.DataAccess;
using Miniaction.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Miniaction.Implementation.UseCases.Queries
{
    public class EFFindStarQuery : IFindStarQuery
    {
        private readonly MiniactionContext _context;
        public EFFindStarQuery(MiniactionContext context)
        {
            _context = context;
        }
        public int ID => 41;

        public string Name => "Find a star";

        public string Description => "Finds a star.";

        public ReadStarDTO Execute(int id)
        {
            Star star = _context.Stars
                              .FirstOrDefault(s => s.ID == id);
            if (star == null)
            {
                throw new Exception("Star is not found.");
            }
            return new ReadStarDTO
            {
                ID = star.ID,
                Score = star.Score,
                Description = star.Description
            };
        }
    }
}
