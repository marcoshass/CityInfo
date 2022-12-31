using CityInfo.Core.SharedKernel.Exceptions;

namespace CityInfo.Api.Exceptions
{
    public class BusinessRuleValidationExceptionProblemDetails : Microsoft.AspNetCore.Mvc.ProblemDetails
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
