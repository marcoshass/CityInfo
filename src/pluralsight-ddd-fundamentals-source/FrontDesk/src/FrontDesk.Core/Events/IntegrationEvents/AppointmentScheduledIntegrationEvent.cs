using PluralsightDdd.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontDesk.Core.Events.IntegrationEvents
{
    public class AppointmentScheduledIntegrationEvent : BaseIntegrationEvent
    {
        public AppointmentScheduledIntegrationEvent()
        {
            DateOccurred = DateTimeOffset.Now;
        }

        public Guid AppointmentId { get; set; }
        public string ClientName { get; set; }
        public string ClientEmailAddress { get; set; }
        public string PatientName { get; set; }
        public string DoctorName { get; set; }
        public string AppointmentType { get; set; }
        public DateTimeOffset AppointmentStartDateTime { get; set; }
        public string EventType => nameof(AppointmentScheduledIntegrationEvent);
    }
}
