using CityInfo.Data.Entities.Customers;
using CityInfo.Domain.Cqrs.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityInfo.Data.Commands.Customers
{
    public class CreateCustomerCommand
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }

    public class CreateCustomerCommandHandler : ICommandHandler<CreateCustomerCommand>
    {
        private readonly CustomersDBContext _context;

        public CreateCustomerCommandHandler(CustomersDBContext context)
        {
            _context = context;
        }

        public void Handle(CreateCustomerCommand command)
        {
            var newCustomer = new TblCustomer
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
                DateOfBirth = command.DateOfBirth
            };
            _context.TblCustomers.Add(newCustomer);
            _context.SaveChanges();

            command.Id = newCustomer.Id;
        }
    }
}
