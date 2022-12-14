using System;
using System.Collections.Generic;

namespace CityInfo.Core.Aggregates;

public partial class Patient
{
    public int Id { get; set; }

    public int ClientId { get; set; }

    public string? Name { get; set; }

    public string? Sex { get; set; }

    public string? AnimalTypeSpecies { get; set; }

    public string? AnimalTypeBreed { get; set; }

    public int? PreferredDoctorId { get; set; }

    public virtual Client Client { get; set; } = null!;
}
