using CityInfo.Core.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityInfo.Core.Services
{
    public interface ICustomerUniquenessChecker
    {
        Task<bool> IsUnique(Customer customer, CancellationToken cancelToken = default(CancellationToken));
    }
}
