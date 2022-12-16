using CityInfo.Domain.Cqrs.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityInfo.Data.Queries.Infrastructure
{
    // Implementation used only by dependency injection
    // for discovery.

    public class DiscoveryQuery : IQuery<object>
    { }

    public class DiscoveryQueryHandler : IQueryHandler<DiscoveryQuery, object>
    {
        public object Handle(DiscoveryQuery query)
        {
            throw new NotImplementedException();
        }
    }
}
