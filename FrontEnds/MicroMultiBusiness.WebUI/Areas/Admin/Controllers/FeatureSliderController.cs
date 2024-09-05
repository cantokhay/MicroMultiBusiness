using MicroMultiBusiness.DTOLayer.CatalogDTOs.FeatureSliderDTOs;
using MicroMultiBusiness.WebUI.Services.CatalogServices.FeatureSliderServices;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Authorization;
//using Newtonsoft.Json;
//using System.Text;

namespace MicroMultiBusiness.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[AllowAnonymous]
    [Route("Admin/FeatureSlider")]
    public class FeatureSliderController : Controller
    {
        //private readonly IHttpClientFactory _httpClientFactory;
        private readonly IFeatureSliderService _featureSliderService;

        public FeatureSliderController(IFeatureSliderService featureSliderService)
        {
            _featureSliderService = featureSliderService;
            //_httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            FeatureSliderViewBagList();

            //var client = _httpClientFactory.CreateClient();
            //var response = await client.GetAsync("http://localhost:7070/api/FeatureSliders");
            //if (response.IsSuccessStatusCode)
            //{
            //    var jsonData = await response.Content.ReadAsStringAsync();
            //    var valuesList = JsonConvert.DeserializeObject<List<ResultFeatureSliderDTO>>(jsonData);
            //    return View(valuesList);
            //}
            //return View();

            var valuesList = await _featureSliderService.GetAllFeatureSlidersAsync();

            return View(valuesList);
        }

        [HttpGet]
        [Route("CreateFeatureSlider")]
        public IActionResult CreateFeatureSlider()
        {
            FeatureSliderViewBagList();

            return View();
        }

        [HttpPost]
        [Route("CreateFeatureSlider")]
        public async Task<IActionResult> CreateFeatureSlider(CreateFeatureSliderDTO createFeatureSliderDTO)
        {
            createFeatureSliderDTO.Status = false;
            //var client = _httpClientFactory.CreateClient();
            //var jsonData = JsonConvert.SerializeObject(createFeatureSliderDTO);
            //StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            //var response = await client.PostAsync("http://localhost:7070/api/FeatureSliders", content);
            //if (response.IsSuccessStatusCode)
            //{
            //    return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });
            //}
            //return View();

            await _featureSliderService.CreateFeatureSliderAsync(createFeatureSliderDTO);

            return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });
        }

        [Route("DeleteFeatureSlider/{id}")]
        public async Task<IActionResult> DeleteFeatureSlider(string id)
        {
            //var client = _httpClientFactory.CreateClient();
            //var response = await client.DeleteAsync("http://localhost:7070/api/FeatureSliders?id=" + id);
            //if (response.IsSuccessStatusCode)
            //{
            //    return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });
            //}
            //return View();

            await _featureSliderService.DeleteFeatureSliderAsync(id);

            return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });
        }

        [Route("UpdateFeatureSlider/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateFeatureSlider(string id)
        {
            FeatureSliderViewBagList();

            //var client = _httpClientFactory.CreateClient();
            //var response = await client.GetAsync("http://localhost:7070/api/FeatureSliders/" + id);
            //if (response.IsSuccessStatusCode)
            //{
            //    var jsonData = await response.Content.ReadAsStringAsync();
            //    var valueToUpdate = JsonConvert.DeserializeObject<UpdateFeatureSliderDTO>(jsonData);
            //    return View(valueToUpdate);
            //}
            //return View();

            var valueToUpdate = await _featureSliderService.GetByIdFeatureSliderAsync(id);

            return View(valueToUpdate);
        }

        [Route("UpdateFeatureSlider/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateFeatureSlider(UpdateFeatureSliderDTO updateFeatureSliderDTO)
        {
            //var client = _httpClientFactory.CreateClient();
            //var jsonData = JsonConvert.SerializeObject(updateFeatureSliderDTO);
            //StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            //var response = await client.PutAsync("http://localhost:7070/api/FeatureSliders", content);
            //if (response.IsSuccessStatusCode)
            //{
            //    return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });
            //}
            //return View();

            await _featureSliderService.UpdateFeatureSliderAsync(updateFeatureSliderDTO);

            return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });
        }

        private void FeatureSliderViewBagList()
        {
            ViewBag.v1 = "Home Page";
            ViewBag.v2 = "Sliders";
            ViewBag.v3 = "Sliders List";
            ViewBag.v0 = "Slider operations";
        }
    }
}