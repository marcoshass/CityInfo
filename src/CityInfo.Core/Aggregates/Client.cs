using CityInfo.Core.SharedKernel.DDD;
using System;
using System.Collections.Generic;

namespace CityInfo.Core.Aggregates;

public class Client : BaseEntity<int>, IAggregateRoot
{
    public int Id { get; private set; }

    public string? FullName { get; private set; }

    public string? PreferredName { get; private set; }

    public string? Salutation { get; private set; }

    public string? EmailAddress { get; private set; }

    public int PreferredDoctorId { get; private set; }

    public virtual ICollection<Patient> Patients { get; } = new List<Patient>();
}
