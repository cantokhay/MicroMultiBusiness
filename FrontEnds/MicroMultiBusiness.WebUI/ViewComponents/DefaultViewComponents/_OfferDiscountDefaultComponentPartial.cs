using MicroMultiBusiness.DTOLayer.CatalogDTOs.OfferDiscountDTOs;
using MicroMultiBusiness.WebUI.Services.CatalogServices.OfferDiscountServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MicroMultiBusiness.WebUI.ViewComponents.DefaultViewComponents
{
    public class _OfferDiscountDefaultComponentPartial : ViewComponent
    {
        //private readonly IHttpClientFactory _httpClientFactory;
        private readonly IOfferDiscountService _offerDiscountService;

        public _OfferDiscountDefaultComponentPartial(IOfferDiscountService offerDiscountService)
        {
            //_httpClientFactory = httpClientFactory;
            _offerDiscountService = offerDiscountService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            //var client = _httpClientFactory.CreateClient();
            //var response = await client.GetAsync("http://localhost:7070/api/OfferDiscounts");
            //if (response.IsSuccessStatusCode)
            //{
            //    var jsonData = await response.Content.ReadAsStringAsync();
            //    var valuesList = JsonConvert.DeserializeObject<List<ResultOfferDiscountDTO>>(jsonData);
            //    return View(valuesList);
            //}
            //return View();

            var valuesList = await _offerDiscountService.GetAllOfferDiscountsAsync();

            return View(valuesList);
        }
    }
}
