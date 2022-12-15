using CityInfo.Core.SharedKernel.DDD;
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

        public Customer() // Required for EF
        { }

        public Customer(Guid id,
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
    }
}
