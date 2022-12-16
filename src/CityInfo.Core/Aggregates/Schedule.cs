using CityInfo.Core.SharedKernel.DDD;
using System;
using System.Collections.Generic;

namespace CityInfo.Core.Aggregates;

public class Schedule : BaseEntity<Guid>, IAggregateRoot
{
    public Guid Id { get; private set; }

    public int ClinicId { get; private set; }

    public virtual ICollection<Appointment> Appointments { get; } = new List<Appointment>();
}
