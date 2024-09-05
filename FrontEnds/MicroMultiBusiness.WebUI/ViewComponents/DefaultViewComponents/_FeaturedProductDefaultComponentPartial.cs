using MicroMultiBusiness.DTOLayer.CatalogDTOs.ProductDTOs;
using MicroMultiBusiness.WebUI.Services.CatalogServices.ProductServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MicroMultiBusiness.WebUI.ViewComponents.DefaultViewComponents
{
    public class _FeaturedProductDefaultComponentPartial : ViewComponent
    {
        //private readonly IHttpClientFactory _httpClientFactory;
        private readonly IProductService _productService;

        public _FeaturedProductDefaultComponentPartial(IProductService productService)
        {
            //_httpClientFactory = httpClientFactory;
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            //var client = _httpClientFactory.CreateClient();
            //var response = await client.GetAsync("http://localhost:7070/api/Products");
            //if (response.IsSuccessStatusCode)
            //{
            //    var jsonData = await response.Content.ReadAsStringAsync();
            //    var valuesList = JsonConvert.DeserializeObject<List<ResultProductDTO>>(jsonData);
            //    return View(valuesList);
            //}
            //return View();

            var valuesList = await _productService.GetAllProductsAsync();
            return View(valuesList);
        }
    }
}
