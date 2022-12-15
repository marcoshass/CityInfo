using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityInfo.Core.Aggregates
{
    public class Customer
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime? Birthday { get; set; }

        public int? Age { get; set; }

        public string Phone { get; set; }

        public static Customer Create(
            string email,
            string name)
        {
            // Check Invariant

            return new Customer
            {
                Id = Guid.NewGuid(),
                FirstName = name,
                LastName = name,
                Birthday = null,
                Age = null,
                Phone = "",
            };
        }
    }
}
