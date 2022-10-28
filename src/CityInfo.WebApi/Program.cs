using CityInfo.Data.Entities;
using CityInfo.Data.Queries.Movies;
using CityInfo.Data.Queries.Users;
using CityInfo.Domain.Cqrs.Query;
using CityInfo.Domain.Entities;
using Microsoft.EntityFrameworkCore;

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

            builder.Services.AddDbContext<MoviesDBContext>(options => options.UseSqlServer("name=ConnectionStrings:MoviesDb"));
            builder.Services.AddScoped<IQueryHandlerAsync<FindUsersBySearchTextQuery, User[]>, FindUsersBySearchTextQueryHandler>();
            builder.Services.AddScoped<IQueryHandlerAsync<FindMoviesByTitleQuery, ICollection<Movie>>, FindMoviesByTitleQueryHandler>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}