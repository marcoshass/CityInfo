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
        Task<bool> isUnique(Customer customer, CancellationToken cancelToken = default(CancellationToken));
    }
}
