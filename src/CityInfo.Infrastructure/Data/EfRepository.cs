using CityInfo.Core.SharedKernel.DDD;
using CityInfo.Core.SharedKernel.Repository;

namespace CityInfo.Infrastructure.Data
{
    public class EfRepository<T> : RepositoryBase<T>, IRepository<T> where T : class, IAggregateRoot
    {
        public EfRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
