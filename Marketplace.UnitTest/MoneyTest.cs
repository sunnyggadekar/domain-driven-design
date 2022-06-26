using Marketplace.Domain;
using Xunit;

namespace Marketplace.UnitTest
{
    public class MoneyTest
    {
        [Fact]
        public void Money_object()
        {
            var firstAmout = new Money(5);
            var seconfAmout = new Money(5);

            Assert.Equal(firstAmout, seconfAmout);
        }

        [Fact]
        public void sum_of_money_gives_full_amount()
        {
            var coin1 = new Money(1);
            var coin2 = new Money(2);
            var coin3 = new Money(2);

            var bankNote = new Money(5);

            Assert.Equal(bankNote, coin1+coin2+coin3);

        }
    }
}
