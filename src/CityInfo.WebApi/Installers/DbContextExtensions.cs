using CityInfo.Data.Entities.Customers;
using CityInfo.Data.Entities.Movies;
using Microsoft.EntityFrameworkCore;

namespace CityInfo.WebApi.Installers
{
    public static class DbContextExtensions
    {
        public static void ConfigureDbContexts(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<MoviesDBContext>(options =>
                options.UseSqlServer($"name=ConnectionStrings:MoviesDb"));
            services.AddDbContext<CustomersDBContext>(options =>
                options.UseSqlServer($"name=ConnectionStrings:CustomersDb"));
        }
    }
}
