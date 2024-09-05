using MicroMultiBusiness.DTOLayer.CatalogDTOs.ProductDetailDTOs;
using MicroMultiBusiness.WebUI.Services.CatalogServices.ProductDetailServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MicroMultiBusiness.WebUI.ViewComponents.ProductDetailViewComponent
{
    public class _ProductDetailDescriptionComponentPartial : ViewComponent
    {
        //private readonly IHttpClientFactory _httpClientFactory;
        private readonly IProductDetailService _productDetailService;

        public _ProductDetailDescriptionComponentPartial(IProductDetailService productDetailService)
        {
            //_httpClientFactory = httpClientFactory;
            _productDetailService = productDetailService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            //var client = _httpClientFactory.CreateClient();
            //var response = await client.GetAsync("http://localhost:7070/api/ProductDetails/GetProductDetailByProductId?id=" + id);
            //if (response.IsSuccessStatusCode)
            //{
            //    var jsonData = await response.Content.ReadAsStringAsync();
            //    var valueToUpdate = JsonConvert.DeserializeObject<UpdateProductDetailDTO>(jsonData);
            //    return View(valueToUpdate);
            //}
            //return View();

            var value = await _productDetailService.GetByProductIdProductDetailAsync(id);
            return View(value);
        }
    }
}
