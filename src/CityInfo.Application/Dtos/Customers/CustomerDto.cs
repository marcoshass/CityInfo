using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityInfo.Application.Dtos.Customers
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
