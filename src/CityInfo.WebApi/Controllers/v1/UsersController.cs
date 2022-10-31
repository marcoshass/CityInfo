using CityInfo.Data.Queries.Users;
using CityInfo.Domain.Cqrs.Query;
using CityInfo.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.WebApi.Controllers.v1
{
    [Route("api/v1/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        //private readonly IQueryHandlerAsync<FindUsersBySearchTextQuery, User[]> _handler;
        public UsersController(/*IQueryHandlerAsync<FindUsersBySearchTextQuery, User[]> handler*/)
        {
            //this._handler = handler;
        }

        [HttpGet]
        public ActionResult Get()
        {
            //var query = new FindUsersBySearchTextQuery
            //{
            //    SearchText = "",
            //    IncludeInactiveUsers = false
            //};

            //User[] users = this._handler.Handle(query).Result;

            //return Ok(users);
            return Ok();
        }
    }
}
