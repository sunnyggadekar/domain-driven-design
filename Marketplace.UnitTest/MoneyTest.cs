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
    }
}
