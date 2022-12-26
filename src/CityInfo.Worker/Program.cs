using CityInfo.Core.SharedKernel.Repositories;
using CityInfo.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CityInfo.Worker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IHost host = Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    IConfiguration config = hostContext.Configuration;
                    services.AddDbContext<AppDbContext>(options => options.UseSqlServer(config.GetConnectionString("Default")));
                    services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
                    services.AddHostedService<Worker>();
                })
                .Build();

            host.Run();
        }
    }
}