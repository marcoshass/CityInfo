using CityInfo.Api.Models.Customers;
using CityInfo.Application.Commands.Customers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CityInfo.Api.Endpoints.Customers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Register customer.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("")]
        [HttpPost]
        [ProducesResponseType(typeof(CreateCustomerResponse), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> Create(
            [FromBody] CreateCustomerRequest request)
        {
            var customer = await _mediator.Send(
                new CreateCustomerCommand(
                    request.FirstName,
                    request.LastName,
                    request.DateOfBirth,
                    request.Phone,
                    request.Address
                )
            );

            return Created(string.Empty, customer);
        }
    }
}
