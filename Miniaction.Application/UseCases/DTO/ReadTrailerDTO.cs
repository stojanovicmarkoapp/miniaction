using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miniaction.Application.UseCases.DTO
{
    public class ReadTrailerDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ReadSerialDTONutshell Serial { get; set; }
    }
}
