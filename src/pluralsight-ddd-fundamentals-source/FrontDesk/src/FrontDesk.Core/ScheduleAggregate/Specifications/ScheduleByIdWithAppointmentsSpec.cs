using Ardalis.Specification;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontDesk.Core.ScheduleAggregate.Specifications
{
    public class ScheduleByIdWithAppointmentsSpec : Specification<Schedule>, ISingleResultSpecification
    {
        public ScheduleByIdWithAppointmentsSpec(Guid scheduleId)
        {
            Query
              .Where(schedule => schedule.Id == scheduleId)
              .Include(schedule => schedule.Appointments); // NOTE: Includes *all* appointments
        }
    }
}
