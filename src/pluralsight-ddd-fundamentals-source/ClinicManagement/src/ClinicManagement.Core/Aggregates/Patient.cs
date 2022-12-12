using ClinicManagement.Core.ValueObjects;
using PluralsightDdd.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Core.Aggregates
{
    public class Patient : BaseEntity<int>
    {
        public int ClientId { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
        public AnimalType AnimalType { get; set; }
        public int? PreferredDoctorId { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
