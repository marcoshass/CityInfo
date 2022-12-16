namespace CityInfo.Api.Models.Orders
{
    public class OrderDto
    {
        public int Id { get; set; }

        public OrderDto(int id)
        {
            Id = id;
        }
    }
}
