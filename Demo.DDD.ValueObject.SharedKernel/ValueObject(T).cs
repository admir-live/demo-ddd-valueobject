using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo.DDD.ValueObject.SharedKernel.Domain
{
    public abstract class ValueObject<T> : IEquatable<ValueObject<T>> where T : ValueObject<T>
    {
        protected abstract IEnumerable<object> EqualityCheckAttributes { get; }

        public virtual bool Equals(ValueObject<T> other)
        {
            return other != null &&
                   GetType() == other.GetType() &&
                   EqualityCheckAttributes.SequenceEqual(second: other.EqualityCheckAttributes);
        }

        public override int GetHashCode()
        {
            return EqualityCheckAttributes
                .Aggregate(seed: 0, func: (hash, a) => hash = hash * 31 + (a?.GetHashCode() ?? 0));
        }

        public override bool Equals(object obj)
        {
            return Equals(other: obj as ValueObject<T>);
        }

        public static bool operator ==(ValueObject<T> left, ValueObject<T> right)
        {
            return Equals(objA: left, objB: right);
        }

        public static bool operator !=(ValueObject<T> left, ValueObject<T> right)
        {
            return !Equals(objA: left, objB: right);
        }
    }
}