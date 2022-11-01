using CityInfo.Data.Entities.Customers;
using CityInfo.Domain.Cqrs.Query;

namespace CityInfo.Data.Queries.Infrastructure
{
    public class GetByIdQuery<T> : IQuery<T> where T : class
    {
        public object Id { get; set; }

        public GetByIdQuery(object id)
        {
            Id = id;
        }
    }

    public class GetByIdQueryHandler<T> : IQueryHandler<GetByIdQuery<T>, T> where T : class
    {
        private readonly CustomersDBContext _context;

        public GetByIdQueryHandler(CustomersDBContext context)
        {
            _context = context;
        }

        public T Handle(GetByIdQuery<T> query)
        {
            var dbSet = _context.Set<T>();
            return dbSet.Find(query.Id);
        }
    }
}
