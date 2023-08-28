using Miniaction.Application.UseCases.DTO;
using Miniaction.Application.UseCases.Queries.Searches;
using Miniaction.Application.UseCases.Queries;
using Miniaction.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Miniaction.Domain.Entities;

namespace Miniaction.Implementation.UseCases.Queries
{
    public class EFSearchGrantsQuery : ISearchGrantsQuery
    {
        private readonly MiniactionContext _context;
        public EFSearchGrantsQuery(MiniactionContext context)
        {
            _context = context;
        }
        public int ID => 28;

        public string Name => "Grants search";

        public string Description => "Searches grants.";

        public IEnumerable<ReadGrantDTO> Execute(GrantSearch search)
        {
            var grants = _context.Grants
                                 .Include(g=>g.Role).AsQueryable();
            if (search.RoleID.HasValue)
            {
                grants = grants.Where(g => g.RoleID == (int)search.RoleID);
            }
            if (!string.IsNullOrEmpty(search.RoleName))
            {
                grants = grants.Where(g => g.Role.Name.Contains(search.RoleName));
            }
            if (search.UseCaseID.HasValue)
            {
                grants = grants.Where(g=>g.UseCaseID==(int)search.UseCaseID);
            }
            return grants.Select(g => new ReadGrantDTO
            {
                ID = g.ID,
                RoleID = g.RoleID,
                RoleName = g.Role.Name,
                UseCaseID = g.UseCaseID
            }).ToList();
        }
    }
}
