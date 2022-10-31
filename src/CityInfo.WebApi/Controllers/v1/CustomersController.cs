using CityInfo.Data.Queries.Customers;
using CityInfo.Domain.Cqrs.Paging;
using CityInfo.Domain.Cqrs.Query;
using CityInfo.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.WebApi.Controllers.v1
{
    [Route("api/v1/customers")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private IQueryHandler<SearchCustomersQuery, PagingResult<Customer>> _handler;

        public CustomersController(IQueryHandler<SearchCustomersQuery, PagingResult<Customer>> handler)
        {
            _handler = handler;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var query = new SearchCustomersQuery(0, 10, "Id ASC");
            var result = _handler.Handle(query);

            return Ok(result);
        }
    }
}
