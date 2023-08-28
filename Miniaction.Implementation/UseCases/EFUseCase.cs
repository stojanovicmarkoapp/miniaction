using Miniaction.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miniaction.Implementation.UseCases
{
    public abstract class EFUseCase
    {
        protected MiniactionContext Context { get; }
        protected EFUseCase(MiniactionContext context)
        {
            Context = context;
        }
    }
}
