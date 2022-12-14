using System;
using System.Collections.Generic;

namespace CityInfo.Core.Aggregates;

public partial class Schedule
{
    public Guid Id { get; set; }

    public int ClinicId { get; set; }

    public virtual ICollection<Appointment> Appointments { get; } = new List<Appointment>();
}
