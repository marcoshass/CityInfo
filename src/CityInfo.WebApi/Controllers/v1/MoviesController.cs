using CityInfo.Data.Queries.Movies;
using CityInfo.Domain.Cqrs.Query;
using CityInfo.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.WebApi.Controllers.v1
{
    [Route("api/v1/movies")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IQueryHandler<FindMoviesByTitleQuery, ICollection<Movie>> _handler;

        public MoviesController(IQueryHandler<FindMoviesByTitleQuery, ICollection<Movie>> handler)
        {
            _handler = handler;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var query = new FindMoviesByTitleQuery
            {
                Title = "Neigh"
            };

            var movies = _handler.Handle(query);
            return Ok(movies);
        }
    }
}
