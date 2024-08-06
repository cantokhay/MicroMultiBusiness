using MicroMultiBusiness.DTOLayer.CatalogDTOs.ProductDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MicroMultiBusiness.WebUI.ViewComponents.ProductListViewComponents
{
    public class _ProductListComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _ProductListComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("http://localhost:7070/api/Products/ProductListWithCategoryByCategoryId?categoryId=" + id);
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var valuesList = JsonConvert.DeserializeObject<List<ResultProductWtihCategoryDTO>>(jsonData);
                return View(valuesList);
            }
            return View();
        }
    }
}
