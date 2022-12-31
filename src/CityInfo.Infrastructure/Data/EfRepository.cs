using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using CityInfo.Core.SharedKernel.DDD;
using CityInfo.Core.SharedKernel.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityInfo.Infrastructure.Data
{
    // We are using the EfRepository from Ardalis.Specification
    // https://github.com/ardalis/Specification/blob/v5/ArdalisSpecificationEF/src/Ardalis.Specification.EF/RepositoryBaseOfT.cs
    public class EfRepository<T> : RepositoryBase<T>, IRepository<T> where T : class, IAggregateRoot
    {
        private readonly DbContext dbContext;

        /// <summary>
        /// AppDbContext must be used since it's the one registered
        /// in the DI container
        /// </summary>
        /// <param name="dbContext"></param>
        public EfRepository(AppDbContext dbContext) 
            : base(dbContext, SpecificationEvaluator.Default)
        {
            this.dbContext = dbContext;
        }

        public EfRepository(AppDbContext dbContext, ISpecificationEvaluator specificationEvaluator)
            : base(dbContext, specificationEvaluator)
        {
            this.dbContext = dbContext;
        }

        /// <inheritdoc/>
        public new virtual async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            await dbContext.Set<T>().AddAsync(entity);

            return entity;
        }

        /// <inheritdoc/>
        public new virtual async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
        {
            await dbContext.Set<T>().AddRangeAsync(entities);

            return entities;
        }

        /// <inheritdoc/>
        public new virtual async Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
        {
            dbContext.Set<T>().Update(entity);
        }

        /// <inheritdoc/>
        public new virtual async Task UpdateRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
        {
            dbContext.Set<T>().UpdateRange(entities);
        }

        /// <inheritdoc/>
        public new virtual async Task DeleteAsync(T entity, CancellationToken cancellationToken = default)
        {
            dbContext.Set<T>().Remove(entity);
        }

        /// <inheritdoc/>
        public new virtual async Task DeleteRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
        {
            dbContext.Set<T>().RemoveRange(entities);
        }
    }
}
