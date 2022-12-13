using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorShared.Models.Appointment
{
    public class ListAppointmentRequest : BaseRequest
    {
        public const string Route = "api/schedule/{ScheduleId}/appointments";
        public Guid ScheduleId { get; set; }
    }
}
