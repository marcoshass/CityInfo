using System.ComponentModel.DataAnnotations;

namespace CityInfo.Api.Models.Orders
{
    public class UpdateOrderRequest
    {
        [Required]
        public decimal Amount { get; set; }
    }
}
