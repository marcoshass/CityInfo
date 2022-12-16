using CityInfo.Domain.Cqrs.Query;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityInfo.Data.Queries.Decorators
{
    public class ValidationQueryHandlerDecorator<TQuery, TResult>
        : IQueryHandler<TQuery, TResult> where TQuery : IQuery<TResult>
    {
        private readonly IQueryHandler<TQuery, TResult> decorated;

        public ValidationQueryHandlerDecorator(IQueryHandler<TQuery, TResult> decorated)
        {
            this.decorated = decorated;
        }

        public TResult Handle(TQuery query)
        {
            Validator.ValidateObject(query, new ValidationContext(query, null, null), true);
            
            return this.decorated.Handle(query);
        }
    }
}
