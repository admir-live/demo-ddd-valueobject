using System;
using System.Collections.Generic;
using Demo.DDD.ValueObject.Data.Exceptions;
using Demo.DDD.ValueObject.SharedKernel.Domain;

namespace Demo.DDD.ValueObject.Data.Model
{
    public sealed class UserName : ValueObject<UserName>
    {
        private UserName(string value)
        {
            Value = value.Trim();
        }

        public string Value { get; set; }
        protected override IEnumerable<object> EqualityCheckAttributes => new List<object> {Value};

        public static UserName Parse(string value)
        {
            if (string.IsNullOrWhiteSpace(value: value))
            {
                throw new InvalidUserNameException(userName: value);
            }

            if (value.Length < 3)
            {
                throw new InvalidUserNameException(userName: value);
            }

            return new UserName(value: value);
        }

        private bool Equals(UserName other)
        {
            return base.Equals(obj: other) && Value == other.Value;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(objA: null, objB: obj))
            {
                return false;
            }

            if (ReferenceEquals(objA: this, objB: obj))
            {
                return true;
            }

            return obj.GetType() == GetType() && Equals(other: (UserName) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(value1: base.GetHashCode(), value2: Value);
        }

        public override string ToString()
        {
            return Value;
        }

        public static implicit operator string(UserName value)
        {
            return value.ToString();
        }

        public static implicit operator UserName(string value)
        {
            return Parse(value: value.Trim());
        }

        public static bool operator ==(UserName left, UserName right)
        {
            return right is { } && left is { } && left.Value == right.Value;
        }

        public static bool operator !=(UserName left, UserName right)
        {
            return !(left == right);
        }
    }
}