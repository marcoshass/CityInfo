using CityInfo.Core.Aggregates;
using CityInfo.Core.Services;
using CityInfo.Core.SharedKernel.DDD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityInfo.Core.Rules
{
    public class CustomerNameMustBeUniqueRule : IBusinessRuleAsync
    {
        private readonly ICustomerUniquenessChecker _custUniqueChecker;
        private readonly Customer _customer;

        public CustomerNameMustBeUniqueRule(
            ICustomerUniquenessChecker custUniqueChecker,
            Customer customer)
        {
            _custUniqueChecker = custUniqueChecker;
            _customer = customer;
        }

        public string Message => "Customer with this name already exists.";

        public async Task<bool> IsBroken()
        {
            var result = !await _custUniqueChecker.IsUnique(_customer);
            return result;
        }
    }
}
