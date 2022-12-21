using CityInfo.Core.Aggregates;
using CityInfo.Core.SharedKernel.Cqrs.Commands;
using CityInfo.Core.SharedKernel.Repositories;
using CityInfo.Core.ValueObjects;
using CityInfo.Infrastructure.Dtos.Customers;
using System.Text;

namespace CityInfo.Infrastructure.Cqrs.Commands
{
    public class CreateCustomerCommand : ICommand<CustomerDto>
    {
        public string FirstName { get; set; }

        public string? LastName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string? Phone { get; set; }

        public Address Address { get; set; }
    }

    public class CreateCustomerCommandHandler : ICommandHandler<CreateCustomerCommand, CustomerDto>
    {
        private readonly IRepository<Customer> _repo;

        public CreateCustomerCommandHandler(IRepository<Customer> repo)
        {
            _repo = repo;
        }

        public async Task<CustomerDto> Handle(CreateCustomerCommand command,
            CancellationToken cancellationToken)
        {
            var newCustomer = await _repo.AddAsync(
                new Customer(Guid.NewGuid(),
                    command.FirstName,
                    command.LastName,
                    command.DateOfBirth,
                    command.Phone,
                    command.Address),
                cancellationToken
            );

            return new CustomerDto(newCustomer.Id);
        }
    }
}
