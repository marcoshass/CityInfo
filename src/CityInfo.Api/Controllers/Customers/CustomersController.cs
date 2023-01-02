using CityInfo.Api.Models.Customers;
using CityInfo.Application.Cqrs.Commands.Customers;
using CityInfo.Application.Dtos.Customers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CityInfo.Api.Controllers.Customers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomersController(IMediator mediator)
        {
            _mediator= mediator;
        }

        /// <summary>
        /// Create customer.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("")]
        [HttpPost]
        [ProducesResponseType(typeof(CustomerDto), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> Create([FromBody] CreateCustomerRequest request,
            CancellationToken cancellationToken = default)
        {
            var newCustomer = await _mediator.Send(
                new CreateCustomerCommand
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    DateOfBirth = request.DateOfBirth,
                    Phone = request.Phone,
                    Address = request.Address,
                }
            );

            return Created(string.Empty, newCustomer);
        }
    }
}
