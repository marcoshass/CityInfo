using Ardalis.GuardClauses;
using FrontDesk.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontDesk.Core.ScheduleAggregate.Guards
{
    public static class ScheduleGuardExtensions
    {
        public static void DuplicateAppointment(this IGuardClause guardClause, IEnumerable<Appointment> existingAppointments, Appointment newAppointment, string parameterName)
        {
            if (existingAppointments.Any(a => a.Id == newAppointment.Id))
            {
                throw new DuplicateAppointmentException("Cannot add duplicate appointment to schedule.", parameterName);
            }
        }
    }
}
