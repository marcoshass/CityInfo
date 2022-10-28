using CityInfo.Data.Entities.Customers;
using CityInfo.Domain.Cqrs.Paging;
using CityInfo.Domain.Cqrs.Query;
using CityInfo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityInfo.Data.Queries.Customers
{
    public class SearchCustomersQuery : IQuery<PagedResult<Customer>>
    {
        public string SearchText { get; set; }
        public PagingInformation Paging { get; set; }
    }

    public class SearchCustomersQueryHandler : IQueryHandler<SearchCustomersQuery, PagedResult<Customer>>
    {
        private readonly CustomersDBContext _context;

        public SearchCustomersQueryHandler(CustomersDBContext context)
        {
            _context = context;
        }

        public PagedResult<Customer> Handle(SearchCustomersQuery query)
        {
            var results =
                from c in _context.TblCustomers
                select new Customer
                {
                    Id = c.Id,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    DateOfBirth = c.DateOfBirth
                };
            return PagedResult<Customer>.ApplyPaging(results, query.Paging);
        }
    }
}
