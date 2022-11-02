using CityInfo.Data.Model;
using CityInfo.Domain.Cqrs.Query;
using CityInfo.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityInfo.Data.Queries.Users
{
    public class GetUserByIdQuery : IQuery<User>
    {
        public string Id { get; set; }
    }

    public class GetUserByIdQueryHandler : IQueryHandlerAsync<GetUserByIdQuery, User>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public GetUserByIdQueryHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<User> Handle(GetUserByIdQuery query, CancellationToken cancelToken)
        {
            var appUser = await _userManager.FindByIdAsync(query.Id);
            if (appUser == null)
            {
                throw new Exception("Not found exception");
            }

            return new User
            {
                Id = appUser.Id,
                UserName = appUser.UserName,
                NormalizedUserName = appUser.NormalizedUserName
            };
        }
    }
}
