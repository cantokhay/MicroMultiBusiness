using MicroMultiBusiness.DTOLayer.CatalogDTOs.FeatureDTOs;
using MicroMultiBusiness.WebUI.Services.CatalogServices.FeatureServices;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Authorization;
//using Newtonsoft.Json;
//using System.Text;

namespace MicroMultiBusiness.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[AllowAnonymous]
    [Route("Admin/Feature")]
    public class FeatureController : Controller
    {
        //private readonly IHttpClientFactory _httpClientFactory;
        private readonly IFeatureService _featureService;

        public FeatureController(IFeatureService featureService)
        {
            //_httpClientFactory = httpClientFactory;
            _featureService = featureService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            FeatureViewBagList();

            //var client = _httpClientFactory.CreateClient();
            //var response = await client.GetAsync("http://localhost:7070/api/Features");
            //if (response.IsSuccessStatusCode)
            //{
            //    var jsonData = await response.Content.ReadAsStringAsync();
            //    var valuesList = JsonConvert.DeserializeObject<List<ResultFeatureDTO>>(jsonData);
            //    return View(valuesList);
            //}
            //return View();

            var valuesList = await _featureService.GetAllFeaturesAsync();

            return View(valuesList);
        }

        [HttpGet]
        [Route("CreateFeature")]
        public IActionResult CreateFeature()
        {
            FeatureViewBagList();

            return View();
        }

        [HttpPost]
        [Route("CreateFeature")]
        public async Task<IActionResult> CreateFeature(CreateFeatureDTO createFeatureDTO)
        {
            //var client = _httpClientFactory.CreateClient();
            //var jsonData = JsonConvert.SerializeObject(createFeatureDTO);
            //StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            //var response = await client.PostAsync("http://localhost:7070/api/Features", content);
            //if (response.IsSuccessStatusCode)
            //{
            //    return RedirectToAction("Index", "Feature", new { area = "Admin" });
            //}
            //return View();

            await _featureService.CreateFeatureAsync(createFeatureDTO);

            return RedirectToAction("Index", "Feature", new { area = "Admin" });
        }

        [Route("DeleteFeature/{id}")]
        public async Task<IActionResult> DeleteFeature(string id)
        {
            //var client = _httpClientFactory.CreateClient();
            //var response = await client.DeleteAsync("http://localhost:7070/api/Features?id=" + id);
            //if (response.IsSuccessStatusCode)
            //{
            //    return RedirectToAction("Index", "Feature", new { area = "Admin" });
            //}
            //return View();

            await _featureService.DeleteFeatureAsync(id);

            return RedirectToAction("Index", "Feature", new { area = "Admin" });
        }

        [Route("UpdateFeature/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateFeature(string id)
        {
            FeatureViewBagList();

            //var client = _httpClientFactory.CreateClient();
            //var response = await client.GetAsync("http://localhost:7070/api/Features/" + id);
            //if (response.IsSuccessStatusCode)
            //{
            //    var jsonData = await response.Content.ReadAsStringAsync();
            //    var valueToUpdate = JsonConvert.DeserializeObject<UpdateFeatureDTO>(jsonData);
            //    return View(valueToUpdate);
            //}
            //return View();

            var valueToUpdate = await _featureService.GetByIdFeatureAsync(id);

            return View(valueToUpdate);
        }

        [Route("UpdateFeature/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureDTO updateFeatureDTO)
        {
            //var client = _httpClientFactory.CreateClient();
            //var jsonData = JsonConvert.SerializeObject(updateFeatureDTO);
            //StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            //var response = await client.PutAsync("http://localhost:7070/api/Features", content);
            //if (response.IsSuccessStatusCode)
            //{
            //    return RedirectToAction("Index", "Feature", new { area = "Admin" });
            //}
            //return View();

            await _featureService.UpdateFeatureAsync(updateFeatureDTO);

            return RedirectToAction("Index", "Feature", new { area = "Admin" });
        }

        private void FeatureViewBagList()
        {
            ViewBag.v1 = "Home Page";
            ViewBag.v2 = "Features";
            ViewBag.v3 = "Features List";
            ViewBag.v0 = "Feature operations";
        }
    }
}
