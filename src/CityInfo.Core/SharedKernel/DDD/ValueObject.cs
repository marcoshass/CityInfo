using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityInfo.Core.SharedKernel.DDD
{
    /// <summary>
    /// See: https://enterprisecraftsmanship.com/posts/value-object-better-implementation/
    /// https://enterprisecraftsmanship.com/posts/entity-vs-value-object-the-ultimate-list-of-differences/ 
    /// </summary>
    [Serializable]
    public abstract class ValueObject : IComparable, IComparable<ValueObject>
    {
        private int? _cachedHashCode;

        protected abstract IEnumerable<object> GetEqualityComponents();

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (GetUnproxiedType(this) != GetUnproxiedType(obj))
            {
                return false;
            }

            ValueObject valueObject = (ValueObject)obj;
            return GetEqualityComponents().SequenceEqual(valueObject.GetEqualityComponents());
        }

        public override int GetHashCode()
        {
            if (!_cachedHashCode.HasValue)
            {
                _cachedHashCode = GetEqualityComponents().Aggregate(1, (current, obj) => current * 23 + (obj?.GetHashCode() ?? 0));
            }

            return _cachedHashCode.Value;
        }

        public int CompareTo(object obj)
        {
            Type unproxiedType = GetUnproxiedType(this);
            Type unproxiedType2 = GetUnproxiedType(obj);
            if (unproxiedType != unproxiedType2)
            {
                return string.Compare(unproxiedType.ToString(), unproxiedType2.ToString(), StringComparison.Ordinal);
            }

            ValueObject obj2 = (ValueObject)obj;
            object[] array = GetEqualityComponents().ToArray();
            object[] array2 = obj2.GetEqualityComponents().ToArray();
            for (int i = 0; i < array.Length; i++)
            {
                int num = CompareComponents(array[i], array2[i]);
                if (num != 0)
                {
                    return num;
                }
            }

            return 0;
        }

        private int CompareComponents(object object1, object object2)
        {
            if (object1 == null && object2 == null)
            {
                return 0;
            }

            if (object1 == null)
            {
                return -1;
            }

            if (object2 == null)
            {
                return 1;
            }

            IComparable comparable = object1 as IComparable;
            if (comparable != null)
            {
                IComparable comparable2 = object2 as IComparable;
                if (comparable2 != null)
                {
                    return comparable.CompareTo(comparable2);
                }
            }

            if (!object1.Equals(object2))
            {
                return -1;
            }

            return 0;
        }

        public int CompareTo(ValueObject other)
        {
            return CompareTo((object)other);
        }

        public static bool operator ==(ValueObject a, ValueObject b)
        {
            if ((object)a == null && (object)b == null)
            {
                return true;
            }

            if ((object)a == null || (object)b == null)
            {
                return false;
            }

            return a.Equals(b);
        }

        public static bool operator !=(ValueObject a, ValueObject b)
        {
            return !(a == b);
        }

        internal static Type GetUnproxiedType(object obj)
        {
            Type type = obj.GetType();
            string text = type.ToString();
            if (text.Contains("Castle.Proxies.") || text.EndsWith("Proxy"))
            {
                return type.BaseType;
            }

            return type;
        }
    }
}
