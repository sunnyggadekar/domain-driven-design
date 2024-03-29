﻿using Marketplace.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Marketplace.UnitTest
{
    public class FakeCurrencyLookup : ICurrencyLookup
    {

        private static readonly IEnumerable<CurrencyDetails>
            _currencies = new[]
            {
                new CurrencyDetails
                {
                    CurrencyCode = "EUR",
                    DecimalPlaces = 2,
                    InUse = true
                },
                new CurrencyDetails
                {
                    CurrencyCode = "USD",
                    DecimalPlaces = 2,
                    InUse = true
                },
                new CurrencyDetails
                {
                    CurrencyCode = "JPY",
                    DecimalPlaces = 2,
                    InUse = true
                },
                new CurrencyDetails
                {
                    CurrencyCode = "DEM",
                    DecimalPlaces = 2,
                    InUse = false
                }
            };

        public CurrencyDetails FindCurrency(string currencyCode)
        {
            var currency = _currencies.FirstOrDefault(x => x.CurrencyCode == currencyCode);
            return currency ?? CurrencyDetails.None;
        }
    }
}
