using System;
using System.Collections.Generic;
using Demo.DDD.ValueObject.SharedKernel.Domain;

namespace Demo.DDD.ValueObject.Data.Model
{
    public sealed class BudApiMetadata : ValueObject<BudApiMetadata>
    {
        private BudApiMetadata(string budCustomerId, string budCustomerSecret)
        {
            BudCustomerId = budCustomerId;
            BudCustomerSecret = budCustomerSecret;
        }

        public string BudCustomerId { get; set; }
        public string BudCustomerSecret { get; set; }
        public bool IsRequired { get; set; }

        protected override IEnumerable<object> EqualityCheckAttributes => new List<object> {BudCustomerId, BudCustomerSecret};

        public static BudApiMetadata Parse(string budCustomerId, string budCustomerSecret)
        {
            if (!string.IsNullOrWhiteSpace(value: budCustomerId) && string.IsNullOrWhiteSpace(value: budCustomerSecret))
            {
                throw new ArgumentNullException(paramName: nameof(budCustomerId));
            }

            return new BudApiMetadata(budCustomerId: budCustomerId, budCustomerSecret: budCustomerSecret);
        }

        public static BudApiMetadata Parse(string rawValue)
        {
            if (string.IsNullOrWhiteSpace(value: rawValue))
            {
                throw new ArgumentNullException(paramName: nameof(rawValue));
            }

            var segments = rawValue.Split(separator: ":");

            return Parse(budCustomerId: segments[0], budCustomerSecret: segments[1]);
        }

        public override string ToString()
        {
            return $"{BudCustomerId}:{BudCustomerSecret}";
        }
    }
}