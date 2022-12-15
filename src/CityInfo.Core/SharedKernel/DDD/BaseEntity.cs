﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityInfo.Core.SharedKernel.Events;

namespace CityInfo.Core.SharedKernel.DDD
{
    /// <summary>
    /// Base types for all Entities which track state using a given Id.
    /// </summary>
    public abstract class BaseEntity<TId>
    {
        public TId Id { get; set; }

        public List<BaseDomainEvent> Events = new List<BaseDomainEvent>();
    }
}
