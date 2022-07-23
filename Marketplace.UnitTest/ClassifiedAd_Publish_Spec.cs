using System;
using Marketplace.Domain;
using Xunit;

namespace Marketplace.UnitTest
{
    public class ClassifiedAd_Publish_Spec

    {
        private static readonly ICurrencyLookup currencyLookup = new FakeCurrencyLookup();
        private readonly ClassifiedAd _classifiedAd;
        public ClassifiedAd_Publish_Spec()
        {
            _classifiedAd = new ClassifiedAd(
                new ClassifiedAdId(Guid.NewGuid()),
                new UserId(Guid.NewGuid())
                );
        }

        [Fact]
        public void Can_publish_a_valid_ad()
        {
            _classifiedAd.SetTitle(ClassifiedAdTitle.FromString("Test ad"));
            _classifiedAd.UpdatePrice(Price.FromDecimal(10.0m, "EUR", currencyLookup));
            _classifiedAd.UpdateText(ClassifiedAdText.FromString("Buy some stuff"));
            _classifiedAd.RequestToPublish();
            Assert.Equal(ClassifiedAd.ClassifiedAdState.PendingReview, _classifiedAd.State);
        }

        [Fact]
        public void Cannot_publish_without_title()
        {
            _classifiedAd.UpdateText(ClassifiedAdText.FromString("Please buy my stuff"));
            _classifiedAd.UpdatePrice(Price.FromDecimal(100.10m, "EUR", new FakeCurrencyLookup()));
            Assert.Throws<InvalidEntityStateException>(() => _classifiedAd.RequestToPublish());
        }

        [Fact]
        public void Cannot_publish_without_text()
        {
            _classifiedAd.UpdatePrice(Price.FromDecimal(100.10m, "EUR", new FakeCurrencyLookup()));
            Assert.Throws<InvalidEntityStateException>(() => _classifiedAd.RequestToPublish());
        }

        [Fact]
        public void Cannot_publish_without_price()
        {
            _classifiedAd.UpdateText(ClassifiedAdText.FromString("Please buy my stuff"));
            Assert.Throws<InvalidEntityStateException>(() => _classifiedAd.RequestToPublish());
        }

        [Fact]
        public void Cannot_publish_with_zero_price()
        {
            _classifiedAd.SetTitle(ClassifiedAdTitle.FromString("Test ad"));
            _classifiedAd.UpdateText(ClassifiedAdText.FromString("Please buy my stuff"));
            _classifiedAd.UpdatePrice(
                Price.FromDecimal(0.0m, "EUR", new FakeCurrencyLookup()));

            Assert.Throws<InvalidEntityStateException>(() => _classifiedAd.RequestToPublish());
        }
    }
}
