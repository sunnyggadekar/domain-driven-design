using System;
using static Marketplace.Contracts.ClassifiedAds;
using System.Threading.Tasks;
using Marketplace.Framework;
using Marketplace.Domain;

namespace Marketplace.Api
{
    public class ClassifiedAdsApplicationService : IApplicationService
    {
        private readonly IClassifiedAdRepository _repository;
        private readonly ICurrencyLookup _currencyLookup;

        public ClassifiedAdsApplicationService(IClassifiedAdRepository repository, ICurrencyLookup currencyLookup)
        {
            _repository = repository;
            _currencyLookup = currencyLookup;
        }

        public Task Handle(object command) => command switch
        {
            V1.Create cmd => HandleCreate(cmd),
            V1.SetTitle cmd => HandleUpdate(cmd.Id, c => c.SetTitle(ClassifiedAdTitle.FromString(cmd.Title))),
            V1.UpdateText cmd => HandleUpdate(cmd.Id, c => c.UpdateText(ClassifiedAdText.FromString(cmd.Text))),
            V1.UpdatePrice cmd => HandleUpdate(cmd.Id, c => c.UpdatePrice(Price.FromDecimal(cmd.Price, cmd.Currency, _currencyLookup))),
            V1.RequestToPublish cmd => HandleUpdate(cmd.Id, c => c.RequestToPublish()),
            _ => Task.CompletedTask
        };

        private async Task HandleCreate(V1.Create cmd)
        {
            if (await _repository.Exists<ClassifiedAd>(cmd.Id.ToString()))
                throw new InvalidOperationException($"Entity with Id {cmd.Id} already exists");
            var classifiedAd = new ClassifiedAd(new ClassifiedAdId(cmd.Id), new UserId(cmd.OwnerId));
            await _repository.Save(classifiedAd);
        }

        private async Task HandleUpdate(Guid classifiedAdId, Action<ClassifiedAd> operation)
        {
            var classifiedAd = await _repository.Load<ClassifiedAd>(classifiedAdId.ToString());
            if (classifiedAd == null)
                throw new InvalidOperationException($"Entity with id {classifiedAdId} cannot be found");

            operation(classifiedAd);

            await _repository.Save(classifiedAd);
        }
    }
}