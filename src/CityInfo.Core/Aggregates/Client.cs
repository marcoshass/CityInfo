using System;
using System.Collections.Generic;

namespace CityInfo.Core.Aggregates;

public partial class Client
{
    public int Id { get; set; }

    public string? FullName { get; set; }

    public string? PreferredName { get; set; }

    public string? Salutation { get; set; }

    public string? EmailAddress { get; set; }

    public int PreferredDoctorId { get; set; }

    public virtual ICollection<Patient> Patients { get; } = new List<Patient>();
}
