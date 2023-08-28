using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miniaction.Application.UseCases.Queries.Searches
{
    public class GrantSearch
    {
        public int? RoleID { get; set; }
        public string RoleName { get; set; }
        public int? UseCaseID { get; set; }
    }
}
