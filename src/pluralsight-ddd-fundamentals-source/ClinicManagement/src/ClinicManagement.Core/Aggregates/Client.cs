﻿using PluralsightDdd.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Core.Aggregates
{
    public class Client : BaseEntity<int>, IAggregateRoot
    {
        public string FullName { get; set; }
        public string PreferredName { get; set; }
        public string Salutation { get; set; }
        public string EmailAddress { get; set; }
        public int PreferredDoctorId { get; set; }
        public IList<Patient> Patients { get; private set; } = new List<Patient>();

        public Client(string fullName,
            string preferredName,
            string salutation,
            int preferredDoctorId,
            string emailAddress)
        {
            FullName = fullName;
            PreferredName = preferredName;
            Salutation = salutation;
            PreferredDoctorId = preferredDoctorId;
            EmailAddress = emailAddress;
        }

        public override string ToString()
        {
            return FullName.ToString();
        }
    }
}
