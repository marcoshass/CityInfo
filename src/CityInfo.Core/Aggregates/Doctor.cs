using CityInfo.Core.SharedKernel.DDD;
using System;
using System.Collections.Generic;

namespace CityInfo.Core.Aggregates;

public class Doctor : BaseEntity<int>, IAggregateRoot
{
    public int Id { get; private set; }

    public string? Name { get; private set; }

    private Doctor()
    { }

    public Doctor(int id, string? name)
    {
        Id = id;
        Name = name;
    }
}
