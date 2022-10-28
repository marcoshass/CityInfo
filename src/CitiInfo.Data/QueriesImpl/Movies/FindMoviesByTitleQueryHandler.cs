using CitiInfo.Data.Entities;
using CityInfo.Domain.Entities;
using CityInfo.Domain.Queries.Infrastructure;
using CityInfo.Domain.Queries.Movies;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitiInfo.Data.QueriesImpl.Movies
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
