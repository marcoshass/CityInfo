using CityInfo.Core.SharedKernel.DDD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityInfo.Core.ValueObjects
{
    public class Address : ValueObject
    {
        public string? Address1 { get; private set; }
        public string? Address2 { get; private set; }
        public string? City { get; private set; }
        public string? State { get; private set; }
        public string? Zip { get; private set; }

        public Address(
            string address1,
            string address2,
            string city,
            string state,
            string zip)
        {
            Address1 = address1;
            Address2 = address2;
            City = city;
            State = state;
            Zip = zip;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Address1;
            yield return Address2;
            yield return City;
            yield return State;
            yield return Zip;
        }
    }
}
