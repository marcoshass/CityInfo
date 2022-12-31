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

    public class GetOrdersQueryHandler : IQueryHandler<GetOrdersQuery, IEnumerable<OrderDto>>
    {
        private readonly IRepository<Customer> _custRepo;

        public GetOrdersQueryHandler(IRepository<Customer> custRepo)
        {
            _custRepo = custRepo;
        }

        public async Task<IEnumerable<OrderDto>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            var customer = await _custRepo.FirstOrDefaultAsync(new CustomerByIdWithOrdersSpec(request.CustomerId), cancellationToken);
            var orders = customer?.Orders ?? Enumerable.Empty<Order>();

            return orders.Select(x => new OrderDto
            {
                Id = x.Id,
                Amount = x.Amount,
                CustomerId = x.CustomerId
            });
        }
    }

    public class CustomerByIdWithOrdersSpec : Specification<Customer>
    {
        public CustomerByIdWithOrdersSpec(Guid customerId)
        {
            Query
                .Where(x => x.Id == customerId)
                .Include(x => x.Orders);
        }
    }
}
