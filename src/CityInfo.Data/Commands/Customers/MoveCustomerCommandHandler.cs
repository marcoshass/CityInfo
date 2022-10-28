using CityInfo.Data.Entities.Customers;
using CityInfo.Domain.Cqrs.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityInfo.Data.Commands.Customers
{
    public class MoveCustomerCommand
    {
        public int Id { get; set; }
    }

    public class MoveCustomerCommandHandler : ICommandHandler<MoveCustomerCommand>
    {
        private readonly CustomersDBContext _context;

        public MoveCustomerCommandHandler(CustomersDBContext context)
        {
            _context = context;
        }

        public void Handle(MoveCustomerCommand command)
        {
            var record = _context.TblCustomers.Find(command.Id);
            if (record != null)
            {
                record.FirstName = "Marcos";
                _context.SaveChanges();
            }
        }
    }
}
