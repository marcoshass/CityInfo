using CityInfo.Core.SharedKernel.DDD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityInfo.Core.Aggregates
{
    public class Order : BaseEntity<int>
    {
        public int Id { get; private set; }
        public decimal Amount { get; private set; }
        public Guid CustomerId { get; private set; }

        private Order() { } // EF Required

        public Order(decimal amount, Guid customerId)
        {
            Amount = amount;
            CustomerId = customerId;
        }
    }
}
