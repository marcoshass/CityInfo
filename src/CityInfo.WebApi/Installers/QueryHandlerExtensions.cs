using CityInfo.Data.Queries.Decorators;
using CityInfo.Data.Queries.Infrastructure;
using CityInfo.Domain.Cqrs.Query;
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
            container.Register(typeof(IQueryHandler<,>), typeof(GetByIdQueryHandler<>));
            container.RegisterDecorator(typeof(IQueryHandler<,>), typeof(ValidationQueryHandlerDecorator<,>));
        }
    }
}
