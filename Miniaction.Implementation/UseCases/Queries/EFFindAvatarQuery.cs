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
    public class EFFindAvatarQuery : IFindAvatarQuery
    {
        private readonly MiniactionContext _context;
        public EFFindAvatarQuery(MiniactionContext context)
        {
            _context = context;
        }
        public int ID => 39;

        public string Name => "Find an avatar";

        public string Description => "Finds an avatar.";

        public ReadAvatarDTO Execute(int id)
        {
            Avatar avatar = _context.Avatars
                              .Include(a=>a.User)
                              .FirstOrDefault(a => a.ID == id);
            if (avatar == null)
            {
                throw new Exception("Avatar is not found.");
            }
            return new ReadAvatarDTO
            {
                ID = avatar.ID,
                Name = avatar.Name,
                User = new ReadUserDTONutshell
                {
                    ID = avatar.User.ID,
                    Username = avatar.User.Username
                }
            };
        }
    }
}
