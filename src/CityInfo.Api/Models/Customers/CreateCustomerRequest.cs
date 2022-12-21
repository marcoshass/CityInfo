using CityInfo.Core.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace CityInfo.Api.Models.Customers
{
    public class CreateCustomerRequest
    {
        public string FirstName { get; set; }

        public string? LastName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string? Phone { get; set; }

        public Address Address { get; set; }
    }
}
