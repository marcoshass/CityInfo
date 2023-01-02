using CityInfo.Api.Exceptions;
using CityInfo.Application.Configuration.Data;
using CityInfo.Application.Cqrs;
using CityInfo.Application.Services;
using CityInfo.Core.Data;
using CityInfo.Core.Services;
using CityInfo.Core.SharedKernel.Exceptions;
using CityInfo.Core.SharedKernel.Repositories;
using CityInfo.Infrastructure.Configuration.Data;
using CityInfo.Infrastructure.Data;
using Hellang.Middleware.ProblemDetails;
using MediatR;
using Microsoft.EntityFrameworkCore;

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

            builder.Services.AddProblemDetails(opts => 
            {
                opts.IncludeExceptionDetails = (ctx, ex) =>
                {
                    var env = ctx.RequestServices.GetRequiredService<IHostEnvironment>();
                    return env.IsDevelopment() || env.IsStaging();
                };
                opts.Map<BusinessRuleValidationException>(ex => new BusinessRuleValidationExceptionDetails(ex));
            });

            var connectionString = builder.Configuration.GetConnectionString("Default");

            builder.Services.AddMediatR(typeof(IQuery<>).Assembly);
            builder.Services.AddScoped<ISqlConnectionFactory>(x => new SqlConnectionFactory(connectionString));
            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));
            builder.Services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            builder.Services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));

            // Domain Services
            builder.Services.AddScoped(typeof(ICustomerUniquenessChecker), typeof(CustomerUniquenessChecker));

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            app.UseProblemDetails();

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