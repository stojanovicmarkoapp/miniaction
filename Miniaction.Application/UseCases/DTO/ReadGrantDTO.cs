﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miniaction.Application.UseCases.DTO
{
    public class ReadGrantDTO
    {
        public int ID { get; set; }
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public int UseCaseID { get; set; }
    }
}
