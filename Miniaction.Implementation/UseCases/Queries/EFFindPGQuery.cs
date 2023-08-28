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
    public class EFFindPGQuery : IFindPGQuery
    {
        private readonly MiniactionContext _context;
        public EFFindPGQuery(MiniactionContext context)
        {
            _context = context;
        }
        public int ID => 33;

        public string Name => "Find a parental guideline";

        public string Description => "Finds a parental guideline.";

        public ReadPGDTO Execute(int id)
        {
            PG pg = _context.PGs
                              .FirstOrDefault(p => p.ID == id);
            if (pg == null)
            {
                throw new Exception("Parental guideline is not found.");
            }
            return new ReadPGDTO
            {
                ID = pg.ID,
                Name = pg.Name,
                Description = pg.Description
            };
        }
    }
}
