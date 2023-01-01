using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityInfo.Application.Cqrs
{
    public interface IQuery<out TResult> : IRequest<TResult>
    { }
}
