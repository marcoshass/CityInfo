using System;
using System.Collections.Generic;

namespace CityInfo.Core.Aggregates;

public partial class Appointment
{
    public Guid Id { get; set; }

    public Guid ScheduleId { get; set; }

    public int ClientId { get; set; }

    public int PatientId { get; set; }

    public int RoomId { get; set; }

    public int DoctorId { get; set; }

    public int AppointmentTypeId { get; set; }

    public DateTimeOffset? TimeRangeStart { get; set; }

    public DateTimeOffset? TimeRangeEnd { get; set; }

    public string? Title { get; set; }

    public DateTimeOffset? DateTimeConfirmed { get; set; }

    public bool? IsPotentiallyConflicting { get; set; }

    public virtual Schedule Schedule { get; set; } = null!;
}
