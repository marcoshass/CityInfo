using CitiInfo.Data.Entities;
using CityInfo.Domain.Entities;
using CityInfo.Domain.Queries.Infrastructure;
using CityInfo.Domain.Queries.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitiInfo.Data.QueriesImpl.Users
{
    public class FindUsersBySearchTextQueryHandler : 
        IQueryHandlerAsync<FindUsersBySearchTextQuery, User[]>
    {
        private readonly MoviesDBContext _context;

        public FindUsersBySearchTextQueryHandler(MoviesDBContext context)
        {
            _context = context;
        }

        public async Task<User[]> Handle(FindUsersBySearchTextQuery query)
        {
            return new User[]
            {
                new User { Id = 1, Name = "John" }
            };
        }
    }
}
