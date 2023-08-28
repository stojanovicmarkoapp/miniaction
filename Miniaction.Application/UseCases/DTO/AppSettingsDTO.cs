using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miniaction.Application.UseCases.DTO
{
    public class AppSettingsDTO
    {
        public JWTSettings JWT { get; set; }
        public string BugSnagKey { get; set; }
        public string PasswordSalt { get; set; }
    }
}
