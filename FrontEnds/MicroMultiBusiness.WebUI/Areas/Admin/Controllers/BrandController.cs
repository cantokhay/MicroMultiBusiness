using MicroMultiBusiness.DTOLayer.CatalogDTOs.BrandDTOs;
using MicroMultiBusiness.WebUI.Services.CatalogServices.BrandServices;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Authorization;
//using Newtonsoft.Json;
//using System.Text;

namespace MicroMultiBusiness.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[AllowAnonymous]
    [Route("Admin/Brand")]
    public class BrandController : Controller
    {
        //private readonly IHttpClientFactory _httpClientFactory;
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            //_httpClientFactory = httpClientFactory;
            _brandService = brandService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            BrandViewBagList();

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

        [HttpGet]
        [Route("CreateBrand")]
        public IActionResult CreateBrand()
        {
            BrandViewBagList();

            return View();
        }

        [HttpPost]
        [Route("CreateBrand")]
        public async Task<IActionResult> CreateBrand(CreateBrandDTO createBrandDTO)
        {
            //var client = _httpClientFactory.CreateClient();
            //var jsonData = JsonConvert.SerializeObject(createBrandDTO);
            //StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            //var response = await client.PostAsync("http://localhost:7070/api/Brands", content);
            //if (response.IsSuccessStatusCode)
            //{
            //    return RedirectToAction("Index", "Brand", new { area = "Admin" });
            //}
            //return View();

            await _brandService.CreateBrandAsync(createBrandDTO);

            return RedirectToAction("Index", "Brand", new { area = "Admin" });
        }

        [Route("DeleteBrand/{id}")]
        public async Task<IActionResult> DeleteBrand(string id)
        {
            //var client = _httpClientFactory.CreateClient();
            //var response = await client.DeleteAsync("http://localhost:7070/api/Brands?id=" + id);
            //if (response.IsSuccessStatusCode)
            //{
            //    return RedirectToAction("Index", "Brand", new { area = "Admin" });
            //}
            //return View();

            await _brandService.DeleteBrandAsync(id);

            return RedirectToAction("Index", "Brand", new { area = "Admin" });
        }

        [Route("UpdateBrand/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateBrand(string id)
        {
            BrandViewBagList();

            //var client = _httpClientFactory.CreateClient();
            //var response = await client.GetAsync("http://localhost:7070/api/Brands/" + id);
            //if (response.IsSuccessStatusCode)
            //{
            //    var jsonData = await response.Content.ReadAsStringAsync();
            //    var valueToUpdate = JsonConvert.DeserializeObject<UpdateBrandDTO>(jsonData);
            //    return View(valueToUpdate);
            //}
            //return View();

            var valueToUpdate = await _brandService.GetByIdBrandAsync(id);

            return View(valueToUpdate);
        }

        [Route("UpdateBrand/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateBrand(UpdateBrandDTO updateBrandDTO)
        {
            //var client = _httpClientFactory.CreateClient();
            //var jsonData = JsonConvert.SerializeObject(updateBrandDTO);
            //StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            //var response = await client.PutAsync("http://localhost:7070/api/Brands", content);
            //if (response.IsSuccessStatusCode)
            //{
            //    return RedirectToAction("Index", "Brand", new { area = "Admin" });
            //}
            //return View();

            await _brandService.UpdateBrandAsync(updateBrandDTO);

            return RedirectToAction("Index", "Brand", new { area = "Admin" });
        }

        private void BrandViewBagList()
        {
            ViewBag.v1 = "Home Page";
            ViewBag.v2 = "Brands";
            ViewBag.v3 = "Brands List";
            ViewBag.v0 = "Brand operations";
        }
    }
}
