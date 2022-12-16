using CityInfo.Domain.Cqrs.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityInfo.Data.Commands.Infrastructure
{
    // Implementation used only by dependency injection
    // for discovery.

    public class DiscoveryCommand
    { }

    public class DiscoveryCommandHandler : ICommandHandler<DiscoveryCommand>
    {
        public void Handle(DiscoveryCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
