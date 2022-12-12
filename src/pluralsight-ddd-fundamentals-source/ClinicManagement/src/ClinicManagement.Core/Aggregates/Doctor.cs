using PluralsightDdd.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Core.Aggregates
{
    public class Doctor : BaseEntity<int>, IAggregateRoot
    {
        public string Name { get; set; }
        public Doctor(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
