using CityInfo.Core.SharedKernel.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CityInfo.Api.Exceptions
{
    public class BusinessRuleValidationExceptionProblemDetails : ProblemDetails
    {
        public BusinessRuleValidationExceptionProblemDetails(BusinessRuleValidationException exception)
        {
            Title = "Business rule validation error";
            Status = StatusCodes.Status409Conflict;
            Detail = exception.Details;
            Type = "https://www.city.info/business-rule-validation-error";
        }
    }
}
