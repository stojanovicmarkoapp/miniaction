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
    public class EFSearchRolesQuery : ISearchRolesQuery
    {
        private readonly MiniactionContext _context;
        public EFSearchRolesQuery(MiniactionContext context)
        {
            _context = context;
        }
        public int ID => 22;

        public string Name => "Roles search";

        public string Description => "Searches roles.";

        public IEnumerable<ReadRoleDTO> Execute(RoleSearch search)
        {
            var roles = _context.Roles
                                 .Include(r=>r.Grants).AsQueryable();
            if (!string.IsNullOrEmpty(search.Name))
            {
                roles = roles.Where(r => r.Name.Contains(search.Name));
            }
            return roles.Select(r => new ReadRoleDTO
            {
                ID = r.ID,
                Name = r.Name,
                UseCaseIDs = r.Grants.Select(g => g.UseCaseID).ToList()
            }).ToList();
        }
    }
}
