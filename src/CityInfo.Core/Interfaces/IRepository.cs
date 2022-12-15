using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityInfo.Core.Interfaces
{
    public interface IRepository<T> : IRepositoryBase<T>, IReadRepositoryBase<T> where T : class
    {
    }
}
