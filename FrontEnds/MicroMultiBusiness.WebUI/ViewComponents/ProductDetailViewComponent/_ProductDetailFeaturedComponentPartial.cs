using MicroMultiBusiness.DTOLayer.CatalogDTOs.ProductDTOs;
using MicroMultiBusiness.WebUI.Services.CatalogServices.ProductServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MicroMultiBusiness.WebUI.ViewComponents.ProductDetailViewComponent
{
    public class _ProductDetailFeaturedComponentPartial : ViewComponent
    {
        //private readonly IHttpClientFactory _httpClientFactory;
        private readonly IProductService _productService;

        public _ProductDetailFeaturedComponentPartial(IProductService productService)
        {
            //_httpClientFactory = httpClientFactory;
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            //var client = _httpClientFactory.CreateClient();
            //var response = await client.GetAsync("http://localhost:7070/api/Products/" + id);
            //if (response.IsSuccessStatusCode)
            //{
            //    var jsonData = await response.Content.ReadAsStringAsync();
            //    var valuesList = JsonConvert.DeserializeObject<ResultProductDTO>(jsonData);
            //    return View(valuesList);
            //}
            //return View();

            var value = await _productService.GetByIdProductAsync(id);
            return View(value);
        }
    }
}
