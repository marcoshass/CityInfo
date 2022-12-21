using CityInfo.Infrastructure.Data;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityInfo.Infrastructure.Cqrs.Commands
{
    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        private readonly AppDbContext _dbContext;

        public CreateCustomerCommandValidator(AppDbContext dbContext)
        {
            _dbContext = dbContext;

            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("FirstName is empty");

            RuleFor(x => new { x.FirstName, x.LastName })
                .Must(x => HaveUniqueName(x.FirstName, x.LastName))
                .WithMessage("FirstName and LastName must be unique");
        }

        private bool HaveUniqueName(string firstName, string lastName)
        {
            return _dbContext.Customers
                .Where(x => x.FirstName == firstName
                    && x.LastName == lastName)
                .Any() == false;
        }
    }
}
