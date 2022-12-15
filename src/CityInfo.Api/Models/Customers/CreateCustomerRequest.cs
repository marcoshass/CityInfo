using System.ComponentModel.DataAnnotations;

namespace CityInfo.Api.Models.Customers
{
    public class CreateCustomerRequest
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
