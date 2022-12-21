using CityInfo.Core.SharedKernel.DDD;
using System;
using System.Collections.Generic;

namespace CityInfo.Core.Aggregates;

public class Client : BaseEntity<int>, IAggregateRoot
{
    public int Id { get; private set; }

    public string? FullName { get; private set; }

    public string? PreferredName { get; private set; }

    public string? Salutation { get; private set; }

    public string? EmailAddress { get; private set; }

    public int PreferredDoctorId { get; private set; }

    private readonly List<Patient> _patients = new List<Patient>();
    public IEnumerable<Patient> Patients => _patients.AsReadOnly();

    private Client()
    { }

    public Client(string? fullName,
        string? preferredName,
        string? salutation,
        string? emailAddress,
        int preferredDoctorId)
    {
        FullName = fullName;
        PreferredName = preferredName;
        Salutation = salutation;
        EmailAddress = emailAddress;
        PreferredDoctorId = preferredDoctorId;
    }

    public Patient AddPatient(Patient patient)
    {
        _patients.Add(patient);

        return patient;
    }
}
