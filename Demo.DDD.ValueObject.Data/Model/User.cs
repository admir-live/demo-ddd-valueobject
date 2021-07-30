using System;
using Omni.SharedKernel.Domain;

namespace Demo.DDD.ValueObject.Data.Model
{
    public sealed class User : BaseEntity<Guid>
    {
        public User(string firstName, string lastName, UserName userName)
        {
            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public UserName UserName { get; set; }

        public override string ToString()
        {
            return $"Hey! I am {FirstName} {LastName}! You can call me '{UserName}'!";
        }
    }
}