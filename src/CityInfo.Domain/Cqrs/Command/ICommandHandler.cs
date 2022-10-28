using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityInfo.Domain.Cqrs.Command
{
    public interface ICommandHandler<TCommand>
    {
        void Handle(TCommand command);
    }
}
