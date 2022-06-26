using System;

namespace Marketplace.Domain
{
    public class Money : IEquatable<Money>
    {
        public decimal Amount { get; }

        public Money(decimal amount) => Amount = amount;

        public bool Equals(Money other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return Amount.Equals(other.Amount);
        }

        public override int GetHashCode() => Amount.GetHashCode();

        public static bool operator ==(Money left, Money right) => Equals(left, right);

        public static bool operator !=(Money left, Money right) => !Equals(left, right);


    }
}
