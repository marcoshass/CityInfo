using FrontDesk.Core.ScheduleAggregate;
using PluralsightDdd.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontDesk.Core.Events
{
    public class AppointmentConfirmedEvent : BaseDomainEvent
    {
        public AppointmentConfirmedEvent(Appointment appointment)
        {
            AppointmentUpdated = appointment;
        }

        public Guid Id { get; private set; } = Guid.NewGuid();

        public Appointment AppointmentUpdated { get; private set; }
    }
}
