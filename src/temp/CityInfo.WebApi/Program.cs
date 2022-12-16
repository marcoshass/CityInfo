using CityInfo.WebApi.Installers;
using SimpleInjector;

namespace CityInfo.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var configuration = builder.Configuration;
            var container = new Container();

            builder.Services.AddControllers();
            builder.Services.ConfigureSwagger(configuration);
            builder.Services.AddLogging();

            builder.Services.ConfigureSimpleInjector(container, configuration);
            builder.Services.ConfigureDbContext(configuration);
            builder.Services.ConfigureQueryHandlers(container, configuration);
            builder.Services.ConfigureCommandHandlers(container, configuration);

            var app = builder.Build();
            app.Services.UseSimpleInjector(container);

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            container.Verify();
            app.Run();
        }
    }
}