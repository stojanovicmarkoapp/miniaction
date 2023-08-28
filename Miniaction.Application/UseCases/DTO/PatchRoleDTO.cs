using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miniaction.Application.UseCases.DTO
{
    public class PatchRoleDTO
    {
        public string Name { get; set; }
        public IEnumerable<int> UseCaseIDs { get; set; }
    }
}
