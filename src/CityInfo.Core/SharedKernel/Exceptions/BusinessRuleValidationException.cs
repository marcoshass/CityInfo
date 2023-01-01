using CityInfo.Core.SharedKernel.DDD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityInfo.Core.SharedKernel.Exceptions
{
    public class BusinessRuleValidationException : Exception
    {
        public IBusinessRuleAsync BrokenRuleAsync { get; }
        public IBusinessRule BrokenRule { get; }

        public string Details { get; }

        public BusinessRuleValidationException(IBusinessRuleAsync brokenRule) : base(brokenRule.Message)
        {
            BrokenRuleAsync = brokenRule;
            Details = brokenRule.Message;
        }

        public BusinessRuleValidationException(IBusinessRule brokenRule) : base(brokenRule.Message)
        {
            BrokenRule = brokenRule;
            Details = brokenRule.Message;
        }

        public override string ToString()
        {
            if (BrokenRuleAsync != null)
            {
                return $"{BrokenRuleAsync.GetType().FullName}: {BrokenRuleAsync.Message}";
            }
            
            return $"{BrokenRule.GetType().FullName}: {BrokenRule.Message}";
        }
    }
}
