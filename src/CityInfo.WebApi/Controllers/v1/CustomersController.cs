using CityInfo.Data.Commands.Customers;
using CityInfo.Data.Queries.Customers;
using CityInfo.Domain.Cqrs.Command;
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
        private ICommandHandler<CreateCustomerCommand> _command;

        public CustomersController(IQueryHandler<SearchCustomersQuery, PagingResult<Customer>> handler,
            ICommandHandler<CreateCustomerCommand> command)
        {
            _handler = handler;
            _command = command;
        }

        [HttpGet("{id}", Name = nameof(GetById))]
        public ActionResult GetById(int id)
        {
            return Ok(id);
        }

        [HttpGet]
        public ActionResult Get(int pageIndex = 0, int pageSize = 10, string ordering = "")
        {
            var query = new SearchCustomersQuery(pageIndex, pageSize, ordering);
            var result = _handler.Handle(query);

            return Ok(result);
        }

        [HttpPost]
        public ActionResult Create(CreateCustomerCommand command)
        {
            _command.Handle(command);
            return CreatedAtRoute(nameof(GetById), new { id = command.Id }, command);
        }
    }
}
