using CityInfo.Core.SharedKernel.DDD;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityInfo.Core.Aggregates
{
    public class Outbox : BaseEntity<Guid>, IAggregateRoot
    {
        public string aggregate_type { get; private set; }

        public string aggregate_id { get; private set; }

        public string type { get; private set; }

        public string payload { get; private set; }

        private Outbox() // Required for EF
        { }

        public Outbox(Guid id,
            string aggregate_type,
            string aggregate_id,
            string type,
            string payload)
        {
            this.Id = id;
            this.aggregate_type = aggregate_type;
            this.aggregate_id = aggregate_id;
            this.type = type;
            this.payload = payload;
        }
    }
}
