using CityInfo.Data.Entities;
using CityInfo.Domain.Cqrs.Query;
using CityInfo.Domain.Entities;

namespace CityInfo.Data.Queries.Users
{
    public class FindUsersBySearchTextQuery : IQuery<User[]>
    {
        public string? SearchText { get; set; }
        public bool IncludeInactiveUsers { get; set; }
    }

    public class FindUsersBySearchTextQueryHandler :
        IQueryHandler<FindUsersBySearchTextQuery, User[]>
    {
        private readonly MoviesDBContext _context;

        public FindUsersBySearchTextQueryHandler(MoviesDBContext context)
        {
            _context = context;
        }

        public User[] Handle(FindUsersBySearchTextQuery query)
        {
            return new User[]
            {
                new User { Id = 1, Name = "John" }
            };
        }
    }
}
