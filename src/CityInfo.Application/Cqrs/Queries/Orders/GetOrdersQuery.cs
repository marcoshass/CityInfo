using Ardalis.Specification;
using CityInfo.Application.Dtos.Orders;
using CityInfo.Core.Aggregates;
using CityInfo.Core.SharedKernel.Repositories;

namespace CityInfo.Application.Cqrs.Queries.Orders
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
