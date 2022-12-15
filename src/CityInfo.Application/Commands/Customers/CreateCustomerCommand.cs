using CityInfo.Application.Dtos.Customers;
using CityInfo.Core.Aggregates;
using CityInfo.Core.SharedKernel.Repository;
using CityInfo.Core.ValueObjects;
using MediatR;

namespace CityInfo.Application.Commands.Customers
{
    public class CreateCustomerCommand : IRequest<CustomerDto>
    {
        public string FirstName { get; set; }

        public string? LastName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string? Phone { get; set; }

        public Address Address { get; set; }

        public CreateCustomerCommand(
            string firstName,
            string? lastName,
            DateTime? dateOfBirth,
            string? phone,
            Address address)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Phone = phone;
            Address = address;
        }
    }

    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CustomerDto>
    {
        private readonly IRepository<Customer> _repository;

        public CreateCustomerCommandHandler(IRepository<Customer> repository)
        {
            _repository = repository;
        }

        public async Task<CustomerDto> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var newCustomer = await _repository.AddAsync(
                new Customer(Guid.NewGuid(),
                    request.FirstName,
                    request.LastName,
                    request.DateOfBirth,
                    request.Phone,
                    request.Address)
            );

            return new CustomerDto { Id = newCustomer.Id };
        }
    }
}
