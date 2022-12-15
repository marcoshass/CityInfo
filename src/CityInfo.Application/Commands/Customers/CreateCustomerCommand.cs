using CityInfo.Application.Dtos.Customers;
using CityInfo.Core.Aggregates;
using CityInfo.Core.Interfaces;
using MediatR;

namespace CityInfo.Application.Commands.Customers
{
    public class CreateCustomerCommand : IRequest<CustomerDto>
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public CreateCustomerCommand(string email, string name)
        {
            Email = email;
            Name = name;
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
            var newCustomer = await _repository.AddAsync(Customer.Create(request.Email, request.Name));
            return new CustomerDto
            {
                Id = newCustomer.Id
            };
        }
    }
}
