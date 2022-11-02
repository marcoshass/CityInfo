﻿using CityInfo.Data.Commands.Customers;
using CityInfo.Data.Model;
using CityInfo.Data.Queries.Customers;
using CityInfo.Data.Queries.Infrastructure;
using CityInfo.Domain.Cqrs.Command;
using CityInfo.Domain.Cqrs.Paging;
using CityInfo.Domain.Cqrs.Query;
using CityInfo.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.WebApi.Controllers.v1.Customers
{
    [Route("api/v1/customers")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IQueryHandler<SearchCustomersQuery, PagingResult<Customer>> _searchQuery;
        private readonly IQueryHandler<GetByIdQuery<TblCustomer>, TblCustomer> _getByIdQuery;
        private readonly ICommandHandler<CreateCustomerCommand> _createCustomerCommand;

        public CustomersController(
            IQueryHandler<SearchCustomersQuery, PagingResult<Customer>> handler,
            IQueryHandler<GetByIdQuery<TblCustomer>, TblCustomer> queryGetById,
            ICommandHandler<CreateCustomerCommand> command)
        {
            _searchQuery = handler;
            _createCustomerCommand = command;
            _getByIdQuery = queryGetById;
        }

        [HttpGet("{id}", Name = nameof(GetById))]
        public ActionResult GetById(int id)
        {
            var customer = _getByIdQuery.Handle(new GetByIdQuery<TblCustomer>(id));
            if (customer == null)
            {
                return NotFound();
            }

            var record = new Customer
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                DateOfBirth = customer.DateOfBirth
            };

            return Ok(record);
        }

        [HttpGet]
        public ActionResult GetAll(int pageIndex = 0, int pageSize = 10, string ordering = "")
        {
            var query = new SearchCustomersQuery(pageIndex, pageSize, ordering);
            var result = _searchQuery.Handle(query);

            return Ok(result);
        }

        [HttpPost]
        public ActionResult Create(CreateCustomerCommand command)
        {
            _createCustomerCommand.Handle(command);
            return CreatedAtRoute(nameof(GetById), new { id = command.Id }, command);
        }
    }
}
