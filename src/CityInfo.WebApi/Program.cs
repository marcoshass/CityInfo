using CityInfo.Data.Entities;
using CityInfo.Data.Queries.Movies;
using CityInfo.Data.Queries.Users;
using CityInfo.Domain.Cqrs.Query;
using CityInfo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using SimpleInjector;

namespace CityInfo.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            // SimpleInjector https://github.com/simpleinjector/SimpleInjector/issues/933#issuecomment-983526727
            builder.Services.AddLogging();
            builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

            var container = new Container();
            container.Options.DefaultLifestyle = Lifestyle.Scoped;
            builder.Services.AddSimpleInjector(container, options => {
                options.AddAspNetCore().AddControllerActivation();
                options.AddLogging();
                options.AddLocalization();
            });

            builder.Services.AddDbContext<MoviesDBContext>(options => options.UseSqlServer("name=ConnectionStrings:MoviesDb"));
            //container.Register<IQueryHandlerAsync<FindUsersBySearchTextQuery, User[]>, FindUsersBySearchTextQueryHandler>(Lifestyle.Scoped);
            //container.Register<IQueryHandler<FindMoviesByTitleQuery, ICollection<Movie>>, FindMoviesByTitleQueryHandler>(Lifestyle.Scoped);

            var repositoryAssembly = typeof(FindMoviesByTitleQueryHandler).Assembly;
            var registrations =
                from type in repositoryAssembly.GetExportedTypes()
                where type.Namespace.StartsWith("CityInfo.Data.Queries")
                from service in type.GetInterfaces()
                select new { service, implementation = type };

            foreach (var reg in registrations)
            {
                container.Register(reg.service, reg.implementation, Lifestyle.Scoped);
            }

            //container.Register(typeof(IQueryHandlerAsync<,>), typeof(IQueryHandlerAsync<,>).Assembly);
            //container.Register(typeof(IQueryHandler<,>), typeof(IQueryHandler<,>).Assembly);

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