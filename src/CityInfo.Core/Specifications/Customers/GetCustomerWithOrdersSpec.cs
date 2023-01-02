using Ardalis.Specification;
using CityInfo.Core.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityInfo.Core.Specifications.Customers
{
    public class GetCustomerWithOrdersSpec : Specification<Customer>, ISingleResultSpecification
    {
        public GetCustomerWithOrdersSpec(Guid customerId)
        {
            Query
                .Where(x => x.Id == customerId)
                .Include(x => x.Orders);
        }
    }
}
