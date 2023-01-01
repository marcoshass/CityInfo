using CityInfo.Application.Dtos.Customers;
using CityInfo.Core.Aggregates;
using CityInfo.Core.Data;
using CityInfo.Core.Services;
using CityInfo.Core.SharedKernel.Repositories;
using System.Text.Json;

namespace CityInfo.Application.Cqrs.Commands.Customers
{
    public class CreateCustomerCommandHandler : ICommandHandler<CreateCustomerCommand, CustomerDto>
    {
        private readonly IRepository<Customer> _custRepo;
        private readonly IRepository<Outbox> _outBoxRepo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICustomerUniquenessChecker _customerUniquenessChecker;

        public CreateCustomerCommandHandler(
            IRepository<Customer> custRepo,
            IRepository<Outbox> outBoxRepo,
            IUnitOfWork unitOfWork,
            ICustomerUniquenessChecker customerUniquenessChecker)
        {
            _custRepo = custRepo;
            _outBoxRepo = outBoxRepo;
            _unitOfWork = unitOfWork;
            _customerUniquenessChecker = customerUniquenessChecker;
        }

        public async Task<CustomerDto> Handle(CreateCustomerCommand command,
            CancellationToken cancelToken)
        {
            var newCustomer = await Customer.Create(Guid.NewGuid(),
                    command.FirstName,
                    command.LastName,
                    command.DateOfBirth,
                    command.Phone,
                    command.Address,
                    _customerUniquenessChecker);

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
