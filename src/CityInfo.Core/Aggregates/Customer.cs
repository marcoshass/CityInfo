using CityInfo.Core.Services;
using CityInfo.Core.SharedKernel.DDD;
using CityInfo.Core.SharedKernel.Exceptions;
using CityInfo.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityInfo.Core.Aggregates
{
    public class Customer : BaseEntity<int>, IAggregateRoot
    {
        public Guid Id { get; private set; }

        public string FirstName { get; private set; }

        public string? LastName { get; private set; }

        public DateTime? DateOfBirth { get; private set; }

        public string? Phone { get; private set; }

        public Address Address { get; private set; }

        private Customer() // Required for EF
        { }

        private Customer(Guid id,
            string firstName,
            string? lastName,
            DateTime? dateOfBirth,
            string? phone,
            Address address)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Phone = phone;
            Address = address;
        }

        public async static Task<Customer> Create(Guid id,
            string firstName,
            string? lastName,
            DateTime? dateOfBirth,
            string? phone,
            Address address,
            ICustomerUniquenessChecker customerUniquenessChecker)
        {
            var newCustomer = new Customer(id, firstName, lastName, dateOfBirth, phone, address);
            if (await customerUniquenessChecker.isUnique(newCustomer))
            {
                throw new BusinessRuleValidationException("Customer with this name already exists");
            }
            return newCustomer;
        }

        private readonly List<Order> _orders = new List<Order>();
        public IEnumerable<Order> Orders => _orders.AsReadOnly();

        public Order AddOrder(Order order)
        {
            _orders.Add(order);

            return order;
        }
    }
}
