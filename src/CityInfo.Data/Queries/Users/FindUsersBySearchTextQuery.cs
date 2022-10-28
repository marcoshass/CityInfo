using CityInfo.Domain.Cqrs.Query;
using CityInfo.Domain.Entities;

namespace CityInfo.Data.Queries.Users
{
    public class FindUsersBySearchTextQuery : IQuery<User[]>
    {
        public string? SearchText { get; set; }
        public bool IncludeInactiveUsers { get; set; }
    }
}
