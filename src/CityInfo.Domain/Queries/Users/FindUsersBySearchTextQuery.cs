using CityInfo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityInfo.Domain.Queries.Users
{
    public class FindUsersBySearchTextQuery : IQuery<User[]>
    {
        public string? SearchText { get; set; }
        public bool IncludeInactiveUsers { get; set; }
    }
}
