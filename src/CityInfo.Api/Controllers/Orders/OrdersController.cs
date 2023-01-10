using CityInfo.Api.Models.Orders;
using CityInfo.Application.Cqrs.Queries.Orders;
using CityInfo.Application.Dtos.Orders;
using CityInfo.Core.Aggregates;
using CityInfo.Core.Data;
using CityInfo.Core.SharedKernel.Repositories;
using CityInfo.Core.Specifications.Customers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CityInfo.Api.Controllers.Orders
{
    [Route("api/customers")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IRepository<Customer> _customerRepo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;

        public OrdersController(
            IRepository<Customer> customerRepo,
            IUnitOfWork unitOfWork,
            IMediator mediator)
        {
            _customerRepo = customerRepo;
            _unitOfWork = unitOfWork;
            _mediator = mediator;
        }

        /// <summary>
        /// Get customer orders.
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        [Route("{customerId}/orders")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<OrderDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetOrders(Guid customerId)
        {
            var orders = await _mediator.Send(new GetOrdersQuery(customerId));

            return Ok(orders);
        }

        /// <summary>
        /// Add order to customer.
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="request"></param>
        /// <param name="cancelToken"></param>
        /// <returns></returns>
        [Route("{customerId}/orders")]
        [HttpPost]
        [ProducesResponseType(typeof(OrderDto), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> AddCustomerOrder(
            Guid customerId,
            CreateOrderRequest request,
            CancellationToken cancelToken = default)
        {
            var customer = await _customerRepo.GetByIdAsync(customerId, cancelToken);
            if (customer == null)
            {
                return NotFound();
            }

            var newOrder = new Order(request.Amount, customerId);
            customer.AddOrder(newOrder);
            
            await _unitOfWork.CommitAsync(cancelToken);

            var response = new OrderDto(newOrder.Id, request.Amount, customerId);
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
            [FromRoute] int orderid,
            [FromBody] UpdateOrderRequest request,
            CancellationToken cancelToken = default)
        {
            var customer = await _customerRepo.FirstOrDefaultAsync(
                new GetCustomerWithOrdersSpec(customerId), cancelToken
            );
            if (customer == null)
            {
                return NotFound();
            }

            var order = customer.Orders.Where(x => x.Id == orderid).FirstOrDefault();
            if (order == null)
            {
                return NotFound();
            }

            order.UpdateAmount(request.Amount);

            await _unitOfWork.CommitAsync(cancelToken);

            return Ok();
        }

        [Route("{customerId}/orders/{orderId}")]
        [HttpDelete]
        [ProducesResponseType(typeof(List<OrderDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteOrder(
            [FromRoute] Guid customerId,
            [FromRoute] int orderId,
            CancellationToken cancelToken = default)
        {
            var customer = await _customerRepo.FirstOrDefaultAsync(
                new GetCustomerWithOrdersSpec(customerId), cancelToken
            );

            if (customer == null)
            {
                return NotFound();
            }

            var removedOrder = customer.RemoveOrder(orderId);
            if (removedOrder == null)
            {
                return NotFound();
            }

            await _unitOfWork.CommitAsync(cancelToken);

            return Ok();
        }
    }
}
