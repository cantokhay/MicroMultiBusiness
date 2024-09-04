using MicroMultiBusiness.DTOLayer.CatalogDTOs.CategoryDTOs;
using MicroMultiBusiness.WebUI.Services.CatalogServices.CategoryServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;

namespace MicroMultiBusiness.WebUI.Controllers
{
    public class TestController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ICategoryService _categoriesService;

        public TestController(IHttpClientFactory httpClientFactory, ICategoryService categoriesService)
        {
            _httpClientFactory = httpClientFactory;
            _categoriesService = categoriesService;
        }

        public async Task<IActionResult> Index()
        {
            string token ="";
            using (var httpClient = new HttpClient())
            {
                var request = new HttpRequestMessage
                {
                    RequestUri = new Uri("http://localhost:5001/connect/token"),
                    Method = HttpMethod.Post,
                    Content = new FormUrlEncodedContent(new Dictionary<string, string>
                    {
                        {"client_id" , "MicroMultiBusinessVisitorId" },
                        {"client_secret", "MicroMultiBusinessSecretKey" },
                        {"grant_type", "client_credentials" }
                    })
                };

                using (var response = await httpClient.SendAsync(request))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        var tokenResponse = JObject.Parse(content);
                        token = tokenResponse["access_token"].ToString();
                    }
                }
            }

            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var responseMessage = await client.GetAsync("http://localhost:7070/api/Categories");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDTO>>(jsonData);
                return View(values);
            }
            return View();
        }

        public IActionResult TestToLayout()
        {
            return View();
        }

        public async Task<IActionResult> GetCategories()
        {
            var categories = await _categoriesService.GetAllCategoriesAsync();
            return View(categories);
        }
    }
}
