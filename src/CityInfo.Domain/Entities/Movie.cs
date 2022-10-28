using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityInfo.Domain.Entities
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string? MovieTitle { get; set; }
        public string? MovieRating { get; set; }
        public int ReleaseYear { get; set; }
    }
}
