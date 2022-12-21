using CityInfo.Core.SharedKernel.Cqrs.Queries;
using CityInfo.Core.SharedKernel.DDD;
using CityInfo.Core.SharedKernel.Repositories;
using CityInfo.Infrastructure.Cqrs.Queries.Orders;
using CityInfo.Infrastructure.Data;
using CityInfo.Infrastructure.Validation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CityInfo.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddMemoryCache();
            builder.Services.AddMediatR(typeof(EfRepository<>).Assembly);

            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
            builder.Services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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