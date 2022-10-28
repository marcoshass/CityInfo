using CityInfo.Data.Entities.Movies;
using CityInfo.Domain.Cqrs.Query;
using CityInfo.Domain.Entities;

namespace CityInfo.Data.Queries.Movies
{
    public class FindMoviesByTitleQuery : IQuery<ICollection<Movie>>
    {
        public string? Title { get; set; }
    }

    public class FindMoviesByTitleQueryHandler :
        IQueryHandler<FindMoviesByTitleQuery, ICollection<Movie>>
    {
        private readonly MoviesDBContext _context;

        public FindMoviesByTitleQueryHandler(MoviesDBContext context)
        {
            _context = context;
        }

        public ICollection<Movie> Handle(FindMoviesByTitleQuery query)
        {
            var result =
                from c in _context.TblMovies
                where
                    c.MovieTitle.Contains(query.Title)
                select new Movie
                {
                    MovieId = c.MovieId,
                    MovieTitle = c.MovieTitle,
                    MovieRating = c.MovieRating,
                    ReleaseYear = c.ReleaseYear
                };

            return result.ToList();
        }
    }
}
