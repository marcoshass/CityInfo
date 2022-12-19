using CityInfo.Api.Models.Customers;
using CityInfo.Core.Aggregates;
using CityInfo.Core.SharedKernel.Repositories;
using CityInfo.Infrastructure.Data;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CityInfo.Api.Endpoints.Customers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IRepository<Customer> _repo;

        public CustomersController(IRepository<Customer> repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Register customer.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("")]
        [HttpPost]
        [ProducesResponseType(typeof(CustomerDto), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> Create([FromBody] CreateCustomerRequest request, 
            CancellationToken cancellationToken = default)
        {
            var newCustomer = await _repo.AddAsync(
                new Customer(Guid.NewGuid(),
                    request.FirstName,
                    request.LastName,
                    request.DateOfBirth,
                    request.Phone,
                    request.Address)
            );

            var response = new CustomerDto(newCustomer.Id);
            await _repo.SaveChangesAsync(cancellationToken);

            return Created(string.Empty, response);
        }
    }
}
