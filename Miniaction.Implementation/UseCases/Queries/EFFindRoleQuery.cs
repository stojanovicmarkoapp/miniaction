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
    public class EFFindRoleQuery : IFindRoleQuery
    {
        private readonly MiniactionContext _context;
        public EFFindRoleQuery(MiniactionContext context)
        {
            _context = context;
        }
        public int ID => 37;

        public string Name => "Find a role";

        public string Description => "Finds a role.";

        public ReadRoleDTO Execute(int id)
        {
            Role role = _context.Roles
                              .Include(x=>x.Grants)
                              .FirstOrDefault(x => x.ID == id);
            if (role == null)
            {
                throw new Exception("Role is not found.");
            }
            return new ReadRoleDTO
            {
                ID = role.ID,
                Name = role.Name,
                UseCaseIDs = role.Grants.Select(g=>g.UseCaseID).ToList()
            };
        }
    }
}
