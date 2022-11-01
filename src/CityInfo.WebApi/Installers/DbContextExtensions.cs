﻿using CityInfo.Data.Entities.Customers;
using Microsoft.EntityFrameworkCore;

namespace CityInfo.WebApi.Installers
{
    public static class DbContextExtensions
    {
        public static void ConfigureDbContext(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<CustomersDBContext>(options =>
                options.UseSqlServer($"name=ConnectionStrings:CustomersDb"));
        }
    }
}
