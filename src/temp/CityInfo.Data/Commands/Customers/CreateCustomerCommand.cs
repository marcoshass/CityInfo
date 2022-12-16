using CityInfo.Data.Model;
using CityInfo.Domain.Cqrs.Command;

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
