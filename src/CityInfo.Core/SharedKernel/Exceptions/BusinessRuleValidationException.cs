using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityInfo.Core.SharedKernel.Exceptions
{
    public class BusinessRuleValidationException : Exception
    {
        public string? Details { get; }

        public BusinessRuleValidationException(string message) : base(message)
        { }

        public BusinessRuleValidationException(string message, string details) : base(message)
        {
            this.Details = details;
        }
    }
}
