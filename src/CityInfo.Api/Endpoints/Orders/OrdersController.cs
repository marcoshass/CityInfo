using CityInfo.Api.Models.Orders;
using CityInfo.Core.Aggregates;
using CityInfo.Core.SharedKernel.Repositories;
using CityInfo.Infrastructure.Data;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading;

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

        /// <summary>
        /// Get Customer orders.
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Add customer order.
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [Route("{customerId}/orders")]
        [HttpPost]
        [ProducesResponseType(typeof(OrderDto),(int)HttpStatusCode.Created)]
        public async Task<IActionResult> AddCustomerOrder(
            Guid customerId, 
            CreateOrderRequest request,
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

        /// <summary>
        /// Update customer order.
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="orderid"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("{customerId}/orders/{orderId}")]
        [HttpPut]
        [ProducesResponseType(typeof(OrderDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateCustomerOrder(
            [FromRoute] Guid customerId,
            [FromRoute] Guid orderid,
            [FromBody] UpdateCustomerOrderRequest request,
            CancellationToken cancellationToken = default)
        {
            var customer = await _customerRepo.GetByIdAsync(customerId, cancellationToken);
            if (customer == null)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
