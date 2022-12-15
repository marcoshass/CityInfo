using CityInfo.Core.SharedKernel.Repository;
using Microsoft.EntityFrameworkCore;

namespace CityInfo.Infrastructure.Data
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T>, IReadRepositoryBase<T> where T : class
    {
        private readonly DbContext dbContext;

        //private readonly ISpecificationEvaluator specificationEvaluator;

        //public RepositoryBase(DbContext dbContext)
        //    : this(dbContext, (ISpecificationEvaluator)SpecificationEvaluator.Default)
        //{
        //}

        public RepositoryBase(DbContext dbContext/*, ISpecificationEvaluator specificationEvaluator*/)
        {
            this.dbContext = dbContext;
            //this.specificationEvaluator = specificationEvaluator;
        }

        public virtual async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default(CancellationToken))
        {
            dbContext.Set<T>().Add(entity);
            await SaveChangesAsync(cancellationToken);
            return entity;
        }

        public virtual async Task UpdateAsync(T entity, CancellationToken cancellationToken = default(CancellationToken))
        {
            dbContext.Entry(entity).State = EntityState.Modified;
            await SaveChangesAsync(cancellationToken);
        }

        public virtual async Task DeleteAsync(T entity, CancellationToken cancellationToken = default(CancellationToken))
        {
            dbContext.Set<T>().Remove(entity);
            await SaveChangesAsync(cancellationToken);
        }

        public virtual async Task DeleteRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default(CancellationToken))
        {
            dbContext.Set<T>().RemoveRange(entities);
            await SaveChangesAsync(cancellationToken);
        }

        public virtual async Task SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await dbContext.SaveChangesAsync(cancellationToken);
        }

        public virtual async Task<T?> GetByIdAsync<TId>(TId id, CancellationToken cancellationToken = default(CancellationToken)) where TId : notnull
        {
            return await dbContext.Set<T>().FindAsync(new object[1] { id }, cancellationToken);
        }

        //public virtual async Task<T?> GetBySpecAsync<Spec>(Spec specification, CancellationToken cancellationToken = default(CancellationToken)) where Spec : ISpecification<T>, ISingleResultSpecification
        //{
        //    return await ApplySpecification(specification).FirstOrDefaultAsync(cancellationToken);
        //}

        //public virtual async Task<TResult> GetBySpecAsync<TResult>(ISpecification<T, TResult> specification, CancellationToken cancellationToken = default(CancellationToken))
        //{
        //    return await ApplySpecification(specification).FirstOrDefaultAsync(cancellationToken);
        //}

        public virtual async Task<List<T>> ListAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await dbContext.Set<T>().ToListAsync(cancellationToken);
        }

        //public virtual async Task<List<T>> ListAsync(ISpecification<T> specification, CancellationToken cancellationToken = default(CancellationToken))
        //{
        //    List<T> list = await ApplySpecification(specification).ToListAsync(cancellationToken);
        //    return (specification.PostProcessingAction == null) ? list : specification.PostProcessingAction!(list).ToList();
        //}

        //public virtual async Task<List<TResult>> ListAsync<TResult>(ISpecification<T, TResult> specification, CancellationToken cancellationToken = default(CancellationToken))
        //{
        //    List<TResult> list = await ApplySpecification(specification).ToListAsync(cancellationToken);
        //    return (specification.PostProcessingAction == null) ? list : specification.PostProcessingAction!(list).ToList();
        //}

        //public virtual async Task<int> CountAsync(ISpecification<T> specification, CancellationToken cancellationToken = default(CancellationToken))
        //{
        //    return await ApplySpecification(specification, evaluateCriteriaOnly: true).CountAsync(cancellationToken);
        //}

        //protected virtual IQueryable<T> ApplySpecification(ISpecification<T> specification, bool evaluateCriteriaOnly = false)
        //{
        //    return specificationEvaluator.GetQuery(dbContext.Set<T>().AsQueryable(), specification, evaluateCriteriaOnly);
        //}

        //protected virtual IQueryable<TResult> ApplySpecification<TResult>(ISpecification<T, TResult> specification)
        //{
        //    if (specification == null)
        //    {
        //        throw new ArgumentNullException("Specification is required");
        //    }

        //    if (specification.Selector == null)
        //    {
        //        throw new SelectorNotFoundException();
        //    }

        //    return specificationEvaluator.GetQuery(dbContext.Set<T>().AsQueryable(), specification);
        //}
    }
}
