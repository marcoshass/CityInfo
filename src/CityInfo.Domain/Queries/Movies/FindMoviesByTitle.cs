using CityInfo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityInfo.Domain.Queries.Movies
{
    public class FindMoviesByTitleQuery : IQuery<ICollection<Movie>>
    {
        public string? Title { get; set; }
    }
}
