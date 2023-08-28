using Miniaction.Application.UseCases.DTO;
using Miniaction.Application.UseCases.Queries.Searches;
using Miniaction.Application.UseCases.Queries;
using Miniaction.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Miniaction.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Miniaction.Implementation.UseCases.Queries
{
    public class EFSearchAvatarsQuery : ISearchAvatarsQuery
    {
        private readonly MiniactionContext _context;
        public EFSearchAvatarsQuery(MiniactionContext context)
        {
            _context = context;
        }
        public int ID => 24;

        public string Name => "Avatars search";

        public string Description => "Searches avatars.";

        public IEnumerable<ReadAvatarDTO> Execute(AvatarSearch search)
        {
            var avatars = _context.Avatars.Include(a => a.User).AsQueryable();
            if (!string.IsNullOrEmpty(search.Name))
            {
                avatars = avatars.Where(a => a.Name.Contains(search.Name));
            }
            if (!string.IsNullOrEmpty(search.Username))
            {
                avatars = avatars.Where(a => a.User.Username.Contains(search.Username));
            }
            if (search.UserID.HasValue)
            {
                avatars = avatars.Where(a => a.UserID == (int)search.UserID);
            }
            return avatars.Select(a => new ReadAvatarDTO
            {
                ID = a.ID,
                Name = a.Name,
                User = new ReadUserDTONutshell
                {
                    ID = a.User.ID,
                    Username = a.User.Username
                }
            }).ToList();
        }
    }
}
