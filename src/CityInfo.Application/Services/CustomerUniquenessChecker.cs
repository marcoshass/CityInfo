using Ardalis.Specification;
using CityInfo.Application.Configuration.Data;
using CityInfo.Core.Aggregates;
using CityInfo.Core.Services;
using Dapper;

namespace CityInfo.Application.Services
{
    public class CustomerUniquenessChecker : ICustomerUniquenessChecker
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public CustomerUniquenessChecker(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<bool> IsUnique(Customer customer, CancellationToken cancelToken)
        {
            var connection = _sqlConnectionFactory.GetOpenConnection();

            const string sql = ""
                + " SELECT 1 							"
                + " FROM								"
                + " 	Customers						"
                + " WHERE							    "
                + " 	1=1								"
                + " 	AND FirstName = @FirstName		"
                + " 	AND LastName = @LastName        ";

            var result = await connection.QueryFirstOrDefaultAsync(sql, new { customer.FirstName, customer.LastName });

            return result == null;
        }
    }
}
