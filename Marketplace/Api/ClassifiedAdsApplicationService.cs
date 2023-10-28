using System;
using static Marketplace.Contracts.ClassifiedAds;
using System.Threading.Tasks;

namespace Marketplace.Api
{
    public class ClassifiedAdsApplicationService : IApplicationService
    {
        public async Task Handle(object command)
        {
            switch (command)
            {
                case V1.Create create:
                    //create a new classified ad
                    break;

                default:
                    throw new InvalidOperationException($"command {command.GetType().FullName} is invalid ");
            }


        }
    }
}