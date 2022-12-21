using CityInfo.Core.SharedKernel.DDD;
using System;
using System.Collections.Generic;

namespace CityInfo.Core.Aggregates;

public class Patient : BaseEntity<int>, IAggregateRoot
{
    public int Id { get; private set; }

    public int ClientId { get; private set; }

    public string? Name { get; private set; }

    public string? Sex { get; private set; }

    public string? AnimalTypeSpecies { get; private set; }

    public string? AnimalTypeBreed { get; private set; }

    public int? PreferredDoctorId { get; private set; }

    public virtual Client Client { get; private set; } = null!;

    private Patient()
    { }

    public Patient(int id,
        int clientId,
        string? name,
        string? sex,
        string? animalTypeSpecies,
        string? animalTypeBreed,
        int? preferredDoctorId,
        Client client)
    {
        Id = id;
        ClientId = clientId;
        Name = name;
        Sex = sex;
        AnimalTypeSpecies = animalTypeSpecies;
        AnimalTypeBreed = animalTypeBreed;
        PreferredDoctorId = preferredDoctorId;
        Client = client;
    }
}
