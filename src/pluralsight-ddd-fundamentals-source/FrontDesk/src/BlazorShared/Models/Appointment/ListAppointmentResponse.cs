using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorShared.Models.Appointment
{
    public class ListAppointmentResponse : BaseResponse
    {
        public List<AppointmentDto> Appointments { get; set; } = new List<AppointmentDto>();

        public int Count { get; set; }

        public ListAppointmentResponse(Guid correlationId) : base(correlationId)
        {
        }

        public ListAppointmentResponse()
        {
        }
    }
}
