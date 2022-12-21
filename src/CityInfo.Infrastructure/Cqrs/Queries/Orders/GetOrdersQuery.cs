using CityInfo.Core.SharedKernel.Cqrs.Queries;
using CityInfo.Infrastructure.Dtos.Orders;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityInfo.Infrastructure.Cqrs.Queries.Orders
{
    public class GetOrdersQuery : IQuery<IEnumerable<OrderDto>>
    {
        public Guid CustomerId { get; set; }

        public GetOrdersQuery(Guid customerId)
        {
            CustomerId = customerId;
        }
    }
}
