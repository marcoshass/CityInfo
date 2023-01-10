using CityInfo.Core.Rules;
using CityInfo.Core.Services;
using CityInfo.Core.SharedKernel.DDD;
using CityInfo.Core.ValueObjects;

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
            ICustomerUniquenessChecker custUniqueChecker)
        {
            var newCustomer = new Customer(id, firstName, lastName, dateOfBirth, phone, address);

            await CheckRuleAsync(new CustomerNameMustBeUniqueRule(custUniqueChecker, newCustomer));

            return newCustomer;
        }

        private readonly List<Order> _orders = new List<Order>();
        public IEnumerable<Order> Orders => _orders.AsReadOnly();

        public Order AddOrder(Order order)
        {
            _orders.Add(order);

            return order;
        }

        public Order RemoveOrder(int orderId)
        {
            var orderToRemove = _orders.Where(x => x.Id == orderId).FirstOrDefault();
            if (orderToRemove != null)
            {
                _orders.Remove(orderToRemove);
            }
            return orderToRemove;
        }
    }
}
