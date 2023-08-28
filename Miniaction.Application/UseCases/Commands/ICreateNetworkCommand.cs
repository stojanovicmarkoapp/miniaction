using Miniaction.Application.UseCases.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Miniaction.Application.UseCases.Commands
{
    public interface ICreateNetworkCommand : ICommand<CreateNetworkDTO>
    {
    }
}
