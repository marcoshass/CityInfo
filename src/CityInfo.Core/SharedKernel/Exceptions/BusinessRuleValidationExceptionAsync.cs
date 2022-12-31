using CityInfo.Core.SharedKernel.DDD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityInfo.Core.SharedKernel.Exceptions
{
    public class BusinessRuleValidationExceptionAsync : Exception
    {
        public IBusinessRuleAsync BrokenRule { get; }

        public string Details { get; }

        public BusinessRuleValidationExceptionAsync(IBusinessRuleAsync brokenRule)
            : base(brokenRule.Message)
        {
            BrokenRule = brokenRule;
            Details = brokenRule.Message;
        }

        public override string ToString()
        {
            return $"{BrokenRule.GetType().FullName}: {BrokenRule.Message}";
        }
    }
}
