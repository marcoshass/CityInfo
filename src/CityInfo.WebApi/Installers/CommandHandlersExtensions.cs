using CityInfo.Data.Commands.Infrastructure;
using CityInfo.Domain.Cqrs.Command;
using SimpleInjector;

namespace CityInfo.WebApi.Installers
{
    /// <summary>
    /// Register all ICommands automatically
    /// </summary>
    public static class CommandHandlersExtensions
    {
        public static void ConfigureCommandHandlers(this IServiceCollection services,
            Container container, IConfiguration configuration)
        {
            var assemblies = new[] { typeof(DiscoveryCommandHandler).Assembly };
            container.Register(typeof(ICommandHandler<>), assemblies, Lifestyle.Scoped);
        }
    }
}