using System;
using System.Collections.Generic;

namespace CityInfo.Core.Aggregates;

public partial class AppointmentType
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Code { get; set; }

    public int Duration { get; set; }
}
