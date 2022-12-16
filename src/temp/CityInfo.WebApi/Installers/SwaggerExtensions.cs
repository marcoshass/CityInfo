namespace CityInfo.WebApi.Installers
{
    public static class SwaggerExtensions
    {
        public static void ConfigureSwagger(this IServiceCollection services, IConfiguration configuration)
        {
            // builder.Services.AddSwagger
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }
    }
}
