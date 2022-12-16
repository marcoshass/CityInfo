﻿using System;
using System.Collections.Generic;

namespace CityInfo.Data.Model
{
    public partial class TblCustomer
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}
