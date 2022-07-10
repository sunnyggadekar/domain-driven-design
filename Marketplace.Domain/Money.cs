using Marketplace.Framework;
using System;

namespace Marketplace.Domain
{
    public class Money : Value<Money>
    {

        private const string DefaultCurrency = "EUR";
        public static Money FromDecimal(decimal amount, string currency = DefaultCurrency) => new(amount, currency);

        public static Money FormString(string amount, string currency = DefaultCurrency) => new(decimal.Parse(amount), currency);

        protected Money(decimal amount, string currencyCode = "EUR")
        {
            if (decimal.Round(amount, 2) != amount)
                throw new ArgumentOutOfRangeException(
                    nameof(amount),
                    "Amount cannot have more than two decimals");
            Amount = amount;
            CurrencyCode = currencyCode;
        }

        public decimal Amount { get; }
        public string CurrencyCode { get; }

        public Money Add(Money summand)
        {
            if (CurrencyCode != summand.CurrencyCode)
                throw new CurrencyMismatchException("Cannot Add amounts with different currency");
            return new(Amount + summand.Amount);
        }

        public Money Subtract(Money subtrahend)
        {
            if (CurrencyCode != subtrahend.CurrencyCode)
                throw new CurrencyMismatchException("Cannot subtract amounts with different currency");
            return new Money(Amount - subtrahend.Amount);
        }

        public static Money operator +(Money summand1, Money summand2) => summand1.Add(summand2);

        public static Money operator -(Money subtrahend1, Money subtrahend2) => subtrahend1.Subtract(subtrahend2);

    }

    public class CurrencyMismatchException : Exception
    {
        public CurrencyMismatchException(string message) : base(message)
        {

        }
    }
}
