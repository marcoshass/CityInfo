using CityInfo.Application.Dtos.Customers;
using CityInfo.Core.Aggregates;
using CityInfo.Core.Data;
using CityInfo.Core.Services;
using CityInfo.Core.SharedKernel.Repositories;
using CityInfo.Core.ValueObjects;
using System.Text.Json;

namespace CityInfo.Application.Cqrs.Commands.Customers
{
    public class CreateCustomerCommand : ICommand<CustomerDto>
    {
        public string FirstName { get; set; }

        public string? LastName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string? Phone { get; set; }

        public Address Address { get; set; }
    }
}
