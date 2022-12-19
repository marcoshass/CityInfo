using System.ComponentModel.DataAnnotations;

namespace CityInfo.Api.Models.Orders
{
    public class UpdateCustomerOrderRequest
    {
        [Required]
        public decimal Amount { get; set; }
    }
}
