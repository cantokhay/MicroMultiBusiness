using MicroMultiBusiness.DTOLayer.CatalogDTOs.FeatureSliderDTOs;
using MicroMultiBusiness.WebUI.Services.CatalogServices.FeatureSliderServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MicroMultiBusiness.WebUI.ViewComponents.DefaultViewComponents
{
    public class _CarouselDefaultComponentPartial : ViewComponent
    {
        //private readonly IHttpClientFactory _httpClientFactory;
        private readonly IFeatureSliderService _featureSliderService;

        public _CarouselDefaultComponentPartial(IFeatureSliderService featureSliderService)
        {
            //_httpClientFactory = httpClientFactory;
            _featureSliderService = featureSliderService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            //var client = _httpClientFactory.CreateClient();
            //var response = await client.GetAsync("http://localhost:7070/api/FeatureSliders");
            //if (response.IsSuccessStatusCode)
            //{
            //    var jsonData = await response.Content.ReadAsStringAsync();
            //    var valuesList = JsonConvert.DeserializeObject<List<ResultFeatureSliderDTO>>(jsonData);
            //    return View(valuesList);
            //}
            //return View();

            var featureSliders = await _featureSliderService.GetAllFeatureSlidersAsync();
            return View(featureSliders);
        }
    }
}
