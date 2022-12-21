using CityInfo.Core.SharedKernel.DDD;
using System;
using System.Collections.Generic;

namespace CityInfo.Core.Aggregates;

public class AppointmentType : BaseEntity<int>, IAggregateRoot
{
    public int Id { get; private set; }

    public string? Name { get; private set; }

    public string? Code { get; private set; }

    public int Duration { get; private set; }

    private AppointmentType()
    { }

    public AppointmentType(int id,
        string? name,
        string? code,
        int duration)
    {
        Id = id;
        Name = name;
        Code = code;
        Duration = duration;
    }
}
