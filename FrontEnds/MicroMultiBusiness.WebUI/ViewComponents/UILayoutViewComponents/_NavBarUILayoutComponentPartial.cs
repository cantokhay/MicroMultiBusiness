using MicroMultiBusiness.DTOLayer.CatalogDTOs.CategoryDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MicroMultiBusiness.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _NavBarUILayoutComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _NavBarUILayoutComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("http://localhost:7070/api/Categories");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var valuesList = JsonConvert.DeserializeObject<List<ResultCategoryDTO>>(jsonData);
                return View(valuesList);
            }
            return View();
        }
    }
}
