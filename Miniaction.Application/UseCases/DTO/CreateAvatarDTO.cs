using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miniaction.Application.UseCases.DTO
{
    public class CreateAvatarDTO
    {
        public int? UserID { get; set; }
        public string Avatar { get; set; }
        public string Label { get; set; }
    }
}
