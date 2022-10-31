using CityInfo.Data.Entities.Customers;
using CityInfo.Domain.Cqrs.Paging;
using CityInfo.Domain.Cqrs.Query;
using CityInfo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;

namespace CityInfo.Data.Queries.Customers
{
    public class SearchCustomersQuery : IQuery<PagingResult<Customer>>
    {
        public string? SearchText { get; set; }
        public string? Ordering { get; set; }
        public PagingInformation Paging { get; set; }

        public SearchCustomersQuery(int pageIndex, int pageSize)
        {
            Paging = new PagingInformation(pageIndex, pageSize);
        }

        public SearchCustomersQuery(int pageIndex, int pageSize, string ordering)
        {
            Paging = new PagingInformation(pageIndex, pageSize);
        }
    }

    public class SearchCustomersQueryHandler : IQueryHandler<SearchCustomersQuery, PagingResult<Customer>>
    {
        private readonly CustomersDBContext _context;

        public SearchCustomersQueryHandler(CustomersDBContext context)
        {
            _context = context;
        }

        public PagingResult<Customer> Handle(SearchCustomersQuery query)
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

            if (!string.IsNullOrEmpty(query.Ordering))
            {
                results = results.OrderBy(query.Ordering);
            }

            return PagingResult<Customer>.ApplyPaging(results, query.Paging);
        }
    }
}
