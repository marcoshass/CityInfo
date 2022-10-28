using CityInfo.Domain.Cqrs.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityInfo.Data.Queries.Infrastructure
{
    // Implementation of IQuery and IQueryHandler used
    // only by dependency injection discovery. Via this
    // class all other queries will be registered in the
    // container automatically

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
