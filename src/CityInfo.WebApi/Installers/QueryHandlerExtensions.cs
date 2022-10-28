using CityInfo.Data.Entities.Movies;
using CityInfo.Data.Queries.Decorators;
using CityInfo.Data.Queries.Infrastructure;
using CityInfo.Data.Queries.Movies;
using CityInfo.Domain.Cqrs.Query;
using Microsoft.EntityFrameworkCore;
using SimpleInjector;

namespace CityInfo.WebApi.Installers
{
    public static class QueryHandlerExtensions
    {
        public static void ConfigureQueryHandlers(this IServiceCollection services,
            Container container, IConfiguration configuration)
        {
            var assemblies = new[] { typeof(DiscoveryQueryHandler).Assembly };
            container.Register(typeof(IQueryHandler<,>), assemblies, Lifestyle.Scoped);
            container.RegisterDecorator(typeof(IQueryHandler<,>), typeof(ValidationQueryHandlerDecorator<,>));
        }
    }
}
