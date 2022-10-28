using System;
using System.Collections.Generic;

namespace CitiInfo.Data.Entities
{
    internal partial class TblMovie
    {
        public int MovieId { get; set; }
        public string? MovieTitle { get; set; }
        public string? MovieRating { get; set; }
        public int ReleaseYear { get; set; }
    }
}
