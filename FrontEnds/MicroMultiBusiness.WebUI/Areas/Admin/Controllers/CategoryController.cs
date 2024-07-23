using MicroMultiBusiness.DTOLayer.CatalogDTOs.CategoryDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace MicroMultiBusiness.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/Category")]
    public class CategoryController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CategoryController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Home Page";
            ViewBag.v2 = "Categories";
            ViewBag.v3 = "Categories List";
            ViewBag.v0 = "Category operations";

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

        [HttpGet]
        [Route("CreateCategory")]
        public IActionResult CreateCategory()
        {
            ViewBag.v1 = "Home Page";
            ViewBag.v2 = "Categories";
            ViewBag.v3 = "Create Category";
            ViewBag.v0 = "Category operations";

            return View();
        }

        [HttpPost]
        [Route("CreateCategory")]
        public async Task<IActionResult> CreateCategory(CreateCategoryDTO createCategoryDTO)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createCategoryDTO);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("http://localhost:7070/api/Categories", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index","Category", new {area = "Admin"});
            }
            return View();
        }

        [Route("DeleteCategory/{id}")]
        public async Task<IActionResult> DeleteCategory(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync("http://localhost:7070/api/Categories?id=" + id);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Category", new { area = "Admin" });
            }
            return View();
        }

        [Route("UpdateCategory/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateCategory(string id)
        {
            ViewBag.v1 = "Home Page";
            ViewBag.v2 = "Categories";
            ViewBag.v3 = "Update Category";
            ViewBag.v0 = "Category operations";

            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("http://localhost:7070/api/Categories/" + id);
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var valueToUpdate = JsonConvert.DeserializeObject<UpdateCategoryDTO>(jsonData);
                return View(valueToUpdate);
            }
            return View();
        }

        [Route("UpdateCategory/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDTO updateCategoryDTO)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateCategoryDTO);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("http://localhost:7070/api/Categories", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Category", new { area = "Admin" });
            }
            return View();
        }
    }
}
