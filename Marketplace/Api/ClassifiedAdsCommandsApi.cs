using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using static Marketplace.Contracts.ClassifiedAds;

namespace Marketplace.Api
{
    [Route("/ad")]
    public class ClassifiedAdsCommandApi : Controller
    {
        private readonly ClassifiedAdsApplicationService _applicationService;

        public ClassifiedAdsCommandApi(ClassifiedAdsApplicationService applicationService)
        {
            _applicationService = applicationService;
        }


        [HttpPost]
        public async Task<IActionResult> Post(V1.Create request)
        {
            await _applicationService.Handle(request);
            return Ok();
        }

        [HttpPut("name")]
        public async Task<IActionResult> Put(V1.SetTitle request)
        {
            await _applicationService.Handle(request);
            return Ok();
        }

        [HttpPut("text")]
        public async Task<IActionResult> Put(V1.UpdateText request)
        {
            await _applicationService.Handle(request);
            return Ok();
        }

        [HttpPut("price")]
        public async Task<IActionResult> Put(V1.UpdatePrice request)
        {
            await _applicationService.Handle(request);
            return Ok();
        }

        [HttpPut("publish")]
        public async Task<IActionResult> Put(V1.RequestToPublish request)
        {
            await _applicationService.Handle(request);
            return Ok();
        }
    }

}