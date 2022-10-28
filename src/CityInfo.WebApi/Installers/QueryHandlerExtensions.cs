using CityInfo.Data.Entities;
using CityInfo.Data.Queries.Infrastructure;
using CityInfo.Domain.Cqrs.Query;
using Microsoft.EntityFrameworkCore;
using SimpleInjector;

namespace CityInfo.WebApi.Installers
{
    public static class QueryHandlerExtensions
    {
        public static void ConfigureQueryHandlers(this IServiceCollection services,
            Container container, IConfiguration configuration, string connectionStringName)
        {
            services.AddDbContext<MoviesDBContext>(options =>
                options.UseSqlServer($"name=ConnectionStrings:{connectionStringName}"));

            // Register all scoped IQueryHandlers
            var assemblies = new[] { typeof(DiscoveryQueryHandler).Assembly };
            container.Register(typeof(IQueryHandler<,>), assemblies, Lifestyle.Scoped);
        }
    }
}
