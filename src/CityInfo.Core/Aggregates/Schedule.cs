using CityInfo.Core.SharedKernel.DDD;
using System;
using System.Collections.Generic;

namespace CityInfo.Core.Aggregates;

public class Schedule : BaseEntity<Guid>, IAggregateRoot
{
    public Guid Id { get; private set; }
    public int ClinicId { get; private set; }

    private readonly List<Appointment> _appointments = new List<Appointment>();
    public IEnumerable<Appointment> Appointments => _appointments.AsReadOnly();
}
