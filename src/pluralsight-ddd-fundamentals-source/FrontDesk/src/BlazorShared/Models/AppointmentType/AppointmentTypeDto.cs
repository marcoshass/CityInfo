using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorShared.Models.AppointmentType
{
    public class AppointmentTypeDto
    {
        public int AppointmentTypeId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int Duration { get; set; }
    }
}
