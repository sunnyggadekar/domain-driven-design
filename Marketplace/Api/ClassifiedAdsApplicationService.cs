using System;
using static Marketplace.Contracts.ClassifiedAds;
using System.Threading.Tasks;
using Marketplace.Framework;
using Marketplace.Domain;

namespace Marketplace.Api
{
    public class ClassifiedAdsApplicationService : IApplicationService
    {
        private readonly IEntityStore _store;
        private ICurrencyLookup _currencyLookup;

        public ClassifiedAdsApplicationService(IEntityStore entityStore, ICurrencyLookup currencyLookup)
        {
            _store = entityStore;
            _currencyLookup = currencyLookup;
        }

        public async Task Handle(object command)
        {
            ClassifiedAd classifiedAd;

            switch (command)
            {
                case V1.Create cmd:
                    if (await _store.Exists<ClassifiedAd>(cmd.Id.ToString()))
                        throw new InvalidOperationException($"Entity with Id {cmd.Id} already exists");

                    classifiedAd = new ClassifiedAd(new ClassifiedAdId(cmd.Id), new UserId(cmd.OwnerId));
                    await _store.Save(classifiedAd);
                    break;

                case V1.SetTitle cmd:
                    classifiedAd = await _store.Load<ClassifiedAd>(cmd.Id.ToString());
                    if (classifiedAd == null)
                        throw new InvalidOperationException($"Entity with id {cmd.Id} cannot be found");

                    classifiedAd.SetTitle(ClassifiedAdTitle.FromString(cmd.Title));
                    await _store.Save(classifiedAd);
                    break;

                case V1.UpdateText cmd:
                    classifiedAd = await _store.Load<ClassifiedAd>(cmd.Id.ToString());
                    if (classifiedAd == null)
                        throw new InvalidOperationException($"Entity with id {cmd.Id} cannot be found");

                    classifiedAd.UpdateText(ClassifiedAdText.FromString(cmd.Text));
                    await _store.Save(classifiedAd);
                    break;

                case V1.UpdatePrice cmd:
                    classifiedAd = await _store.Load<ClassifiedAd>(cmd.Id.ToString());
                    if (classifiedAd == null)
                        throw new InvalidOperationException($"Entity with id {cmd.Id} cannot be found");

                    classifiedAd.UpdatePrice(Price.FromDecimal(cmd.Price, cmd.Currency, _currencyLookup));
                    await _store.Save(classifiedAd);
                    break;

                case V1.RequestToPublish cmd:
                    classifiedAd = await _store.Load<ClassifiedAd>(cmd.Id.ToString());
                    if (classifiedAd == null)
                        throw new InvalidOperationException($"Entity with id {cmd.Id} cannot be found");

                    classifiedAd.RequestToPublish();
                    await _store.Save(classifiedAd);
                    break;

                default:
                    throw new InvalidOperationException($"command  type {command.GetType().FullName} is unknown ");
            }


        }
    }
}