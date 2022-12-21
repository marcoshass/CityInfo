using CityInfo.Infrastructure.Dtos.Orders;

namespace CityInfo.Api.Models.Orders
{
    public class GetOrdersResponse
    {
        public IEnumerable<OrderDto> Orders { get; set; }
        public GetOrdersResponse(IEnumerable<OrderDto> orders)
        {
            Orders= orders;
        }
    }
}
