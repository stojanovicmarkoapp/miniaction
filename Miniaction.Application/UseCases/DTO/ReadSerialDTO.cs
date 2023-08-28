using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miniaction.Application.UseCases.DTO
{
    public class ReadSerialDTO
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Features { get; set; }
        public int Released { get; set; }
        public ReadPGDTONutshell PG { get; set; }
        public string TrailerName { get; set; }
        public ReadGenreDTONutshell Genre { get; set; }
        public ReadNetworkDTONutshell Network { get; set; }
        public IEnumerable<ReadOptionDTONutshell> Options { get; set; }
    }
}
