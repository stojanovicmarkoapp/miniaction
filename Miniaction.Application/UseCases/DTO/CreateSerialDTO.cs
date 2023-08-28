﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miniaction.Application.UseCases.DTO
{
    public class CreateSerialDTO
    {
        public string Title { get; set; }
        public string Features { get; set; }
        public int? Released { get; set; }
        public int? PGID { get; set; }
        public int? GenreID { get; set; }
        public int? NetworkID { get; set; }
        public string Trailer { get; set; }
        public string TrailerLabel { get; set; }
    }
}
