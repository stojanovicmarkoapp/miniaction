using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miniaction.Application
{
    public interface IApplicationActor
    {
        int ID { get; }
        string Username { get; }
        string EmailAddress { get; }
        int RoleID { get; }
        IEnumerable<int> UseCaseIDs { get; }
    }
}
