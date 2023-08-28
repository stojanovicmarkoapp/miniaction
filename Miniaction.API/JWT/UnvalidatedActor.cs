using Miniaction.Application;
using System.Collections;
using System.Collections.Generic;

namespace Miniaction.API.JWT
{
    public class UnvalidatedActor : IApplicationActor
    {
        public int ID => 0;
        public string Username => "?";
        public string EmailAddress => "?";
        public int RoleID => 0;
        public IEnumerable<int> UseCaseIDs => new List<int> { 9 };
    }
}
