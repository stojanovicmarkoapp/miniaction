using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miniaction.Application.UseCases
{
    public interface IUseCase
    {
        int ID { get; }
        string Name { get; }
        string Description { get; }
    }
}
