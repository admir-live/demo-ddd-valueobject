using System;

namespace Demo.DDD.ValueObject.Data.Exceptions
{
    [Serializable]
    public class InvalidUserNameException : InvalidCastException
    {
        public InvalidUserNameException(string userName) : base(message: $"The value '{userName}' is not valid for UserName. The UserName should be at least 3 characters.")
        {
        }
    }
}