namespace CityInfo.Api.Models.Customers
{
    public class CustomerDto
    {
        public Guid Id { get; set; }

        public CustomerDto(Guid id)
        {
            Id = id;
        }
    }
}
