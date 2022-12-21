using Ardalis.Specification.EntityFrameworkCore;
using CityInfo.Core.SharedKernel.Cqrs.Queries;
using CityInfo.Infrastructure.Data;
using CityInfo.Infrastructure.Dtos.Orders;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace CityInfo.Infrastructure.Cqrs.Queries.Orders
{
    public class GetOrdersQueryHandler : IQueryHandler<GetOrdersQuery, IEnumerable<OrderDto>>
    {
        private readonly AppDbContext _dbContext;

        public GetOrdersQueryHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<OrderDto>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            var orders = await _dbContext.Orders
                .Where(x => x.CustomerId == request.CustomerId)
                .ToListAsync();

            return orders.Select(x => new OrderDto
            {
                Id = x.Id,
                Amount = x.Amount,
                CustomerId = x.CustomerId
            });
        }
    }
}
