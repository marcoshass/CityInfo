using CityInfo.Domain.Cqrs.Query;
using CityInfo.Domain.Entities;

namespace CityInfo.Data.Queries.Movies
{
    public class FindMoviesByTitleQuery : IQuery<ICollection<Movie>>
    {
        public string? Title { get; set; }
    }
}
