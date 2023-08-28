﻿using Miniaction.Application.UseCases.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miniaction.Application.UseCases.Queries
{
    public interface IFindSerialQuery : IQuery<int, ReadSerialDTO>
    {
    }
}
