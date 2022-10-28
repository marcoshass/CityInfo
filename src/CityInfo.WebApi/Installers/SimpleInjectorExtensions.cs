using SimpleInjector;

namespace CityInfo.WebApi.Installers
{
    // How to configure in .NET 6 https://github.com/simpleinjector/SimpleInjector/issues/933#issuecomment-983526727
    public static class SimpleInjectorExtensions
    {
        public static void ConfigureSimpleInjector(this IServiceCollection services, 
            Container container, IConfiguration configuration)
        {
            container.Options.DefaultLifestyle = Lifestyle.Scoped;
            services.AddLocalization(options => options.ResourcesPath = "Resources");
            services.AddSimpleInjector(container, options => {
                options.AddAspNetCore().AddControllerActivation();
                options.AddLogging();
                options.AddLocalization();
            });
        }
    }
}
