using CityInfo.Data.Entities;
using CityInfo.Domain.Cqrs.Query;
using CityInfo.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CityInfo.Data.Queries.Movies
{
    public class FindMoviesByTitleQueryHandler :
        IQueryHandlerAsync<FindMoviesByTitleQuery, ICollection<Movie>>
    {
        private readonly MoviesDBContext _context;

        public FindMoviesByTitleQueryHandler(MoviesDBContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Movie>> Handle(FindMoviesByTitleQuery query)
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

            return await result.ToListAsync();
        }
    }
}
