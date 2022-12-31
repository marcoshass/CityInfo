using CityInfo.Application.Dtos.Customers;
using CityInfo.Core.Aggregates;
using CityInfo.Core.Data;
using CityInfo.Core.SharedKernel.Repositories;
using CityInfo.Core.ValueObjects;
using System.Text.Json;

namespace CityInfo.Application.Cqrs.Commands.Customers
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
        private readonly IRepository<Customer> _custRepo;
        private readonly IRepository<Outbox> _outBoxRepo;
        private readonly IUnitOfWork _unitOfWork;

        public CreateCustomerCommandHandler(
            IRepository<Customer> custRepo,
            IRepository<Outbox> outBoxRepo,
            IUnitOfWork unitOfWork)
        {
            _custRepo = custRepo;
            _outBoxRepo = outBoxRepo;
            _unitOfWork = unitOfWork;
        }

        public async Task<CustomerDto> Handle(CreateCustomerCommand command,
            CancellationToken cancelToken)
        {
            var newCustomer = new Customer(Guid.NewGuid(),
                    command.FirstName,
                    command.LastName,
                    command.DateOfBirth,
                    command.Phone,
                    command.Address);

            await _custRepo.AddAsync(newCustomer, cancelToken);

            var newEvent = new Outbox(Guid.NewGuid(),
                nameof(Customer),
                newCustomer.Id.ToString(),
                "Customer_Added",
                JsonSerializer.Serialize(newCustomer)
            );

            await _outBoxRepo.AddAsync(newEvent, cancelToken);

            await _unitOfWork.CommitAsync(cancelToken);

            return new CustomerDto(newCustomer.Id);
        }
    }
}
