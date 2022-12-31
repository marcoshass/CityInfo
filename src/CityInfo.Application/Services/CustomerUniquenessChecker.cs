using Ardalis.Specification;
using CityInfo.Core.Aggregates;
using CityInfo.Core.Services;
using CityInfo.Core.SharedKernel.Repositories;

namespace CityInfo.Application.Services
{
    public class CustomerUniquenessChecker : ICustomerUniquenessChecker
    {
        private readonly IRepository<Customer> _custRepo;

        public CustomerUniquenessChecker(
            IRepository<Customer> custRepo)
        {
            _custRepo = custRepo;
        }

        public async Task<bool> isUnique(Customer customer, CancellationToken cancelToken)
        {
            var result = await _custRepo.AnyAsync(
                new CustomersWithNameSpec(customer),
                cancelToken
            );

            return result;
        }
    }

    public class CustomersWithNameSpec : Specification<Customer>
    {
        public CustomersWithNameSpec(Customer customer)
        {
            Query
                .Where(
                    x => x.FirstName == customer.FirstName && 
                    x.LastName == customer.LastName
                );
        }
    }
}
