using System.ComponentModel.DataAnnotations;

namespace CityInfo.Api.Models.Orders
{
    public class CreateOrderRequest
    {
        [Required]
        public decimal Amount { get; set; }
    }
}
