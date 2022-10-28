using CityInfo.Domain.Entities;
using CityInfo.Domain.Queries;
using CityInfo.Domain.Queries.Movies;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.WebApi.Controllers.v1
{
    [Route("api/movies")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IQueryHandlerAsync<FindMoviesByTitleQuery, ICollection<Movie>> _handler;

        public MoviesController(IQueryHandlerAsync<FindMoviesByTitleQuery, ICollection<Movie>> handler)
        {
            _handler = handler;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var query = new FindMoviesByTitleQuery
            {
                Title = "Neigh"
            };

            var movies = await _handler.Handle(query);
            return Ok(movies);
        }
    }
}
