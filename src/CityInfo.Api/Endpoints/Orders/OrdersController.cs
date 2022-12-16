using CityInfo.Api.Models.Orders;
using CityInfo.Core.Aggregates;
using CityInfo.Infrastructure.Data;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CityInfo.Api.Endpoints.Orders
{
    [Route("api/customers")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IRepository<Customer> _customerRepo;

        public OrdersController(IRepository<Customer> customerRepo)
        {
            _customerRepo = customerRepo;
        }

        [Route("{customerId}/orders")]
        [HttpGet]
        [ProducesResponseType(typeof(GetOrdersResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetOrders(Guid customerId)
        {
            //var orders = await _mediator.Send(new GetOrdersQuery(customerId));
            //var response = new GetOrdersResponse(orders);
            //return Ok(response);
            return Ok();
        }

        [Route("{customerId}/orders")]
        [HttpPost]
        [ProducesResponseType(typeof(OrderDto),(int)HttpStatusCode.Created)]
        public async Task<IActionResult> Create(Guid customerId, CreateOrderRequest request,
            CancellationToken cancellationToken = default)
        {
            var customer = await _customerRepo.GetByIdAsync(customerId, cancellationToken);
            if (customer == null)
            {
                return NotFound();
            }

            var newOrder = new Order(request.Amount, customerId);
            customer.AddOrder(newOrder);
            await _customerRepo.UpdateAsync(customer, cancellationToken);

            var response = new OrderDto(newOrder.Id);
            return Created(string.Empty, response);
        }


    }
}
