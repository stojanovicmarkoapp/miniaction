using Miniaction.Application.UseCases.DTO;
using Miniaction.Application.UseCases.Queries.Searches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miniaction.Application.UseCases.Queries
{
    public interface ISearchFormatsQuery : IQuery<FormatSearch, IEnumerable<ReadFormatDTO>>
    {
    }
}
