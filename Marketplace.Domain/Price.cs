﻿using System;

namespace Marketplace.Domain
{
    public class Price : Money
    {

        private Price(
            decimal amount,
            string currencyCode,
            ICurrencyLookup currencyLookup)
            : base(amount, currencyCode, currencyLookup)
        {
            if (amount < 0)
                throw new ArgumentException(
                    "Price cannot be negative",
                    nameof(amount));
        }

        internal Price(decimal amount, string currencyCode) : base(amount, new CurrencyDetails { CurrencyCode = currencyCode }) { }
        public static new Price FromDecimal(decimal amount, string currency, ICurrencyLookup currencyLookup) =>
            new(amount, currency, currencyLookup);

    }


}
