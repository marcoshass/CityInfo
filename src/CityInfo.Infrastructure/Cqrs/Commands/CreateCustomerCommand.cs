using Ardalis.Specification;
using CityInfo.Core.Aggregates;
using CityInfo.Core.SharedKernel.Cqrs.Commands;
using CityInfo.Core.SharedKernel.Repositories;
using CityInfo.Core.ValueObjects;
using CityInfo.Infrastructure.Data;
using CityInfo.Infrastructure.Dtos.Customers;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Text.Json;

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
        private readonly AppDbContext _dbContext;


        public CreateCustomerCommandHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CustomerDto> Handle(CreateCustomerCommand command,
            CancellationToken cancellationToken)
        {
            var newCustomer = new Customer(Guid.NewGuid(),
                    command.FirstName,
                    command.LastName,
                    command.DateOfBirth,
                    command.Phone,
                    command.Address);

            await _dbContext.Customers.AddAsync(newCustomer, cancellationToken);

            var newEvent = new Outbox(Guid.NewGuid(),
                nameof(Customer),
                newCustomer.Id.ToString(),
                "Customer_Added",
                JsonSerializer.Serialize(newCustomer)
            );
            
            await _dbContext.Outboxes.AddAsync(newEvent, cancellationToken);

            await _dbContext.SaveChangesAsync();

            return new CustomerDto(newCustomer.Id);
        }
    }
}
