using MicroMultiBusiness.DTOLayer.CatalogDTOs.BrandDTOs;
using MicroMultiBusiness.WebUI.Services.CatalogServices.BrandServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MicroMultiBusiness.WebUI.ViewComponents.DefaultViewComponents
{
    public class _VendorDefaultComponentPartial : ViewComponent
    {
        //private readonly IHttpClientFactory _httpClientFactory;
        private readonly IBrandService _brandService;

        public _VendorDefaultComponentPartial(IBrandService brandService)
        {
            //_httpClientFactory = httpClientFactory;
            _brandService = brandService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            //var client = _httpClientFactory.CreateClient();
            //var response = await client.GetAsync("http://localhost:7070/api/Brands");
            //if (response.IsSuccessStatusCode)
            //{
            //    var jsonData = await response.Content.ReadAsStringAsync();
            //    var valuesList = JsonConvert.DeserializeObject<List<ResultBrandDTO>>(jsonData);
            //    return View(valuesList);
            //}
            //return View();

            var valuesList = await _brandService.GetAllBrandsAsync();
            return View(valuesList);
        }
    }
}
