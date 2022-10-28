using CityInfo.Data.Commands.Customers;
using CityInfo.Data.Queries.Customers;
using CityInfo.Domain.Cqrs.Command;
using CityInfo.Domain.Cqrs.Paging;
using CityInfo.Domain.Cqrs.Query;
using CityInfo.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.WebApi.Controllers.v1
{
    [Route("api/customers")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private IQueryHandler<SearchCustomersQuery, PagedResult<Customer>> _handler;

        public CustomersController(IQueryHandler<SearchCustomersQuery, PagedResult<Customer>> handler)
        {
            _handler = handler;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var query = new SearchCustomersQuery
            {
                Paging = new PagingInformation(1, 10)
            };

            var result = _handler.Handle(query);

            return Ok(result.Page);
        }
    }
}
