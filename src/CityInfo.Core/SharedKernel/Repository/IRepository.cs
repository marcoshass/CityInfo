﻿using CityInfo.Core.SharedKernel.DDD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityInfo.Core.SharedKernel.Repository
{
    public interface IRepository<T> : IRepositoryBase<T>, IReadRepositoryBase<T> where T : class, IAggregateRoot
    {
    }
}
