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
    public class EFFindGenreQuery : IFindGenreQuery
    {
        private readonly MiniactionContext _context;
        public EFFindGenreQuery(MiniactionContext context)
        {
            _context = context;
        }
        public int ID => 30;

        public string Name => "Find a genre";

        public string Description => "Finds a genre.";

        public ReadGenreDTO Execute(int id)
        {
            Genre genre = _context.Genres
                              .FirstOrDefault(g => g.ID == id);
            if (genre == null)
            {
                throw new Exception("Genre is not found.");
            }
            return new ReadGenreDTO
            {
                ID = genre.ID,
                Name = genre.Name
            };
        }
    }
}
