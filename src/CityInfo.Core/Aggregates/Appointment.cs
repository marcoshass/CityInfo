using CityInfo.Core.SharedKernel.DDD;
using System;
using System.Collections.Generic;

namespace CityInfo.Core.Aggregates;

public class Appointment : BaseEntity<Guid>
{
    public Guid Id { get; private set; }

    public Guid ScheduleId { get; private set; }

    public int ClientId { get; private set; }

    public int PatientId { get; private set; }

    public int RoomId { get; private set; }

    public int DoctorId { get; private set; }

    public int AppointmentTypeId { get; private set; }

    public DateTimeOffset? TimeRangeStart { get; private set; }

    public DateTimeOffset? TimeRangeEnd { get; private set; }

    public string? Title { get; private set; }

    public DateTimeOffset? DateTimeConfirmed { get; private set; }

    public bool? IsPotentiallyConflicting { get; private set; }

    public virtual Schedule Schedule { get; private set; } = null!;

    private Appointment()
    {

    }

    public Appointment(Guid id, 
        Guid scheduleId, 
        int clientId, 
        int patientId, 
        int roomId, 
        int doctorId, 
        int appointmentTypeId, 
        DateTimeOffset? timeRangeStart, 
        DateTimeOffset? timeRangeEnd, 
        string? title, 
        DateTimeOffset? dateTimeConfirmed, 
        bool? isPotentiallyConflicting, 
        Schedule schedule)
    {
        Id = id;
        ScheduleId = scheduleId;
        ClientId = clientId;
        PatientId = patientId;
        RoomId = roomId;
        DoctorId = doctorId;
        AppointmentTypeId = appointmentTypeId;
        TimeRangeStart = timeRangeStart;
        TimeRangeEnd = timeRangeEnd;
        Title = title;
        DateTimeConfirmed = dateTimeConfirmed;
        IsPotentiallyConflicting = isPotentiallyConflicting;
        Schedule = schedule;
    }
}
