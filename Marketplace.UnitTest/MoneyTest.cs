using Marketplace.Domain;
using System;
using Xunit;

namespace Marketplace.UnitTest
{
    public class MoneyTest
    {
        private static readonly ICurrencyLookup currencyLookup = new FakeCurrencyLookup();

        [Fact]
        public void Two_of_same_amount_should_be_equal()
        {
            var firstAmount = Money.FromDecimal(5, "EUR", currencyLookup);
            var secondAmount = Money.FromDecimal(5, "EUR", currencyLookup);
            Assert.Equal(firstAmount, secondAmount);
        }

        [Fact]
        public void Two_of_same_amount_but_different_currencies_should_not_be_equal()
        {
            var firstAmount = Money.FromDecimal(5, "EUR", currencyLookup);
            var secondAmount = Money.FromDecimal(5, "USD", currencyLookup);
            Assert.NotEqual(firstAmount, secondAmount);
        }

        [Fact]
        public void FromString_and_FromDecimal_should_be_equal()
        {
            var firstAmount = Money.FromDecimal(5, "EUR", currencyLookup);
            var secondAmount = Money.FormString("5.00", "EUR", currencyLookup);
            Assert.Equal(firstAmount, secondAmount);
        }

        [Fact]
        public void Sum_of_money_gives_full_amount()
        {
            var coin1 = Money.FromDecimal( 1, "USD", currencyLookup);
            var coin2 = Money.FormString( "2", "USD", currencyLookup);
            var coin3 = Money.FormString( "3", "USD", currencyLookup);
            var bankNote = Money.FormString( "6.00", "USD", currencyLookup);
            Assert.Equal(bankNote, coin1 + coin2 + coin3);
        }

        [Fact]
        public void Unused_currency_should_not_be_allowed()
        {
            Assert.Throws<ArgumentException>(() => Money.FromDecimal( 100, "DEM", currencyLookup ));
        }

        [Fact]
        public void Unknow_currency_should_not_be_allowed()
        {
            Assert.Throws<ArgumentException>(() => Money.FromDecimal( 100, "WHAT?", currencyLookup));
        }

        [Fact]
        public void Throw_when_too_many_decimal_places()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>Money.FromDecimal(100.123m, "EUR", currencyLookup) );
        }

    }
}
