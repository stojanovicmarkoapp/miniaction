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
    public class EFFindGrantQuery : IFindGrantQuery
    {
        private readonly MiniactionContext _context;
        public EFFindGrantQuery(MiniactionContext context)
        {
            _context = context;
        }
        public int ID => 43;

        public string Name => "Find a grant";

        public string Description => "Finds a grant.";

        public ReadGrantDTO Execute(int id)
        {
            Grant grant = _context.Grants
                              .Include(g=>g.Role)
                              .FirstOrDefault(g => g.ID == id);
            if (grant == null)
            {
                throw new Exception("Grant is not found.");
            }
            return new ReadGrantDTO
            {
                ID = grant.ID,
                RoleID = grant.RoleID,
                RoleName = grant.Role.Name,
                UseCaseID = grant.UseCaseID
            };
        }
    }
}
