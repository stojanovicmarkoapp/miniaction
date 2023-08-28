using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miniaction.Application.UseCases.DTO
{
    public class CreateTrailerDTO
    {
        public int? SerialID { get; set; }
        public string Trailer { get; set; }
        public string Label { get; set; }
    }
}
