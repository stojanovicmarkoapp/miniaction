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
    public class EFFindFormatQuery : IFindFormatQuery
    {
        private readonly MiniactionContext _context;
        public EFFindFormatQuery(MiniactionContext context)
        {
            _context = context;
        }
        public int ID => 31;

        public string Name => "Find a format";

        public string Description => "Finds a format.";

        public ReadFormatDTO Execute(int id)
        {
            Format format = _context.Formats
                              .FirstOrDefault(f => f.ID == id);
            if (format == null)
            {
                throw new Exception("Format is not found.");
            }
            return new ReadFormatDTO
            {
                ID = format.ID,
                Name = format.Name
            };
        }
    }
}
