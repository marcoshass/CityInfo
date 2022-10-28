using CityInfo.Data.Commands.Customers;
using CityInfo.Domain.Cqrs.Command;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.WebApi.Controllers.v1
{
    [Route("api/customers")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private ICommandHandler<MoveCustomerCommand> _handler;

        public CustomersController(ICommandHandler<MoveCustomerCommand> handler)
        {
            _handler = handler;
        }

        [HttpPost]
        public ActionResult Post()
        {
            var command = new MoveCustomerCommand
            {
                Id = 1
            };

            _handler.Handle(command);

            return Ok();
        }
    }
}
