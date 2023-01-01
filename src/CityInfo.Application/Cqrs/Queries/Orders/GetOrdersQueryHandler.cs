using CityInfo.Application.Configuration.Data;
using CityInfo.Application.Dtos.Orders;
using Dapper;

namespace CityInfo.Application.Cqrs.Queries.Orders
{
    public class GetOrdersQueryHandler : IQueryHandler<GetOrdersQuery, IEnumerable<OrderDto>>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetOrdersQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<IEnumerable<OrderDto>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            const string sql = ""
                + " SELECT *                     "
                + " FROM                         "
                + "     Orders                   "
                + " WHERE                        "
                + "     CustomerId = @CustomerId ";

            var connection = _sqlConnectionFactory.GetOpenConnection();

            return await connection.QueryAsync<OrderDto>(sql, new { request.CustomerId });
        }
    }
}
