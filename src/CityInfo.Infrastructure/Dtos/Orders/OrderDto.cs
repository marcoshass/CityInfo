using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityInfo.Infrastructure.Dtos.Orders
{
    public class OrderDto
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public Guid CustomerId { get; set; }

        public OrderDto()
        {

        }

        public OrderDto(int id)
        {
            Id = id;
        }
    }
}
