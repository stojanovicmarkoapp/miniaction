using Miniaction.Application;
using System.Collections;
using System.Collections.Generic;

namespace Miniaction.API.JWT
{
    public class JWTActor : IApplicationActor
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string EmailAddress { get; set; }
        public int RoleID { get; set; }
        public IEnumerable<int> UseCaseIDs { get; set; }
    }
}
