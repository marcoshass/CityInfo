using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityInfo.Core.SharedKernel.Repository
{
    public interface IReadRepositoryBase<T> where T : class
    {
        Task<T?> GetByIdAsync<TId>(TId id, CancellationToken cancellationToken = default) where TId : notnull;
        //Task<T?> GetBySpecAsync<Spec>(Spec specification, CancellationToken cancellationToken = default(CancellationToken)) where Spec : ISingleResultSpecification, ISpecification<T>;
        //Task<TResult> GetBySpecAsync<TResult>(ISpecification<T, TResult> specification, CancellationToken cancellationToken = default(CancellationToken));
        Task<List<T>> ListAsync(CancellationToken cancellationToken = default);
        //Task<List<T>> ListAsync(ISpecification<T> specification, CancellationToken cancellationToken = default(CancellationToken));
        //Task<List<TResult>> ListAsync<TResult>(ISpecification<T, TResult> specification, CancellationToken cancellationToken = default(CancellationToken));
        //Task<int> CountAsync(ISpecification<T> specification, CancellationToken cancellationToken = default(CancellationToken));
    }
}
