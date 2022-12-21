using CityInfo.Api.Models.Orders;
using CityInfo.Core.Aggregates;
using CityInfo.Core.SharedKernel.Repositories;
using CityInfo.Infrastructure.Cqrs.Queries.Orders;
using CityInfo.Infrastructure.Dtos.Orders;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CityInfo.Api.Controllers.CustomersOrders
{
    [Route("api/customers")]
    [ApiController]
    public class CustomerOrdersController : ControllerBase
    {
        private readonly IRepository<Customer> _customerRepo;
        private readonly IMediator _mediator;

        public CustomerOrdersController(IRepository<Customer> customerRepo,
            IMediator mediator)
        {
            _customerRepo = customerRepo;
            _mediator = mediator;
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
            var orders = await _mediator.Send(new GetOrdersQuery(customerId));

            var response = new GetOrdersResponse(orders);

            return Ok(response);
        }


        [Route("{customerId}/orders/{orderId}")]
        [HttpGet]
        [ProducesResponseType(typeof(OrderDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetCustomerOrderDetails([FromRoute] int orderId)
        {
            // Há 02 opções aqui:
            // 1 - Criar um query method que utiliza o include ou consulta
            // a tabela Order diretamente, isso é conceitualmente errado pois
            // permite consultar Order diretamente sem passar por um Customer

            // 2 - Utilizar o framework specification e permitir o include
            // das Orders do Customer. Conceitualmente este approach é mais
            // correto pois permite a query apenas pelo AggregateRoot

            //var order = await _orderRepo.GetByIdAsync(orderId);
            //if (order == null)
            //{
            //    return NotFound();
            //}

            //var response = new OrderDto
            //{
            //    Id = order.Id,
            //    Amount = order.Amount,
            //    CustomerId = order.CustomerId,
            //};

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
        [ProducesResponseType(typeof(OrderDto), (int)HttpStatusCode.Created)]
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
