using MicroMultiBusiness.DTOLayer.CatalogDTOs.AboutDTOs;
using MicroMultiBusiness.WebUI.Services.CatalogServices.AboutServices;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Authorization;
//using Newtonsoft.Json;
//using System.Text;

namespace MicroMultiBusiness.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[AllowAnonymous]
    [Route("Admin/About")]
    public class AboutController : Controller
    {
        //private readonly IHttpClientFactory _httpClientFactory;
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            //_httpClientFactory = httpClientFactory;
            _aboutService = aboutService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            AboutViewBagList();

            //var client = _httpClientFactory.CreateClient();
            //var response = await client.GetAsync("http://localhost:7070/api/Abouts");
            //if (response.IsSuccessStatusCode)
            //{
            //    var jsonData = await response.Content.ReadAsStringAsync();
            //    var valuesList = JsonConvert.DeserializeObject<List<ResultAboutDTO>>(jsonData);
            //    return View(valuesList);
            //}
            //return View();

            var valuesList = await _aboutService.GetAllAboutsAsync();

            return View(valuesList);
        }

        [HttpGet]
        [Route("CreateAbout")]
        public IActionResult CreateAbout()
        {
            AboutViewBagList();

            return View();
        }

        [HttpPost]
        [Route("CreateAbout")]
        public async Task<IActionResult> CreateAbout(CreateAboutDTO createAboutDTO)
        {
            //var client = _httpClientFactory.CreateClient();
            //var jsonData = JsonConvert.SerializeObject(createAboutDTO);
            //StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            //var response = await client.PostAsync("http://localhost:7070/api/Abouts", content);
            //if (response.IsSuccessStatusCode)
            //{
            //    return RedirectToAction("Index", "About", new { area = "Admin" });
            //}
            //return View();

            await _aboutService.CreateAboutAsync(createAboutDTO);

            return RedirectToAction("Index", "About", new { area = "Admin" });
        }

        [Route("DeleteAbout/{id}")]
        public async Task<IActionResult> DeleteAbout(string id)
        {
            //var client = _httpClientFactory.CreateClient();
            //var response = await client.DeleteAsync("http://localhost:7070/api/Abouts?id=" + id);
            //if (response.IsSuccessStatusCode)
            //{
            //    return RedirectToAction("Index", "About", new { area = "Admin" });
            //}
            //return View();

            await _aboutService.DeleteAboutAsync(id);

            return RedirectToAction("Index", "About", new { area = "Admin" });
        }

        [Route("UpdateAbout/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateAbout(string id)
        {
            AboutViewBagList();

            //var client = _httpClientFactory.CreateClient();
            //var response = await client.GetAsync("http://localhost:7070/api/Abouts/" + id);
            //if (response.IsSuccessStatusCode)
            //{
            //    var jsonData = await response.Content.ReadAsStringAsync();
            //    var valueToUpdate = JsonConvert.DeserializeObject<UpdateAboutDTO>(jsonData);
            //    return View(valueToUpdate);
            //}
            //return View();

            var valueToUpdate = await _aboutService.GetByIdAboutAsync(id);

            return View(valueToUpdate);
        }

        [Route("UpdateAbout/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDTO updateAboutDTO)
        {
            //var client = _httpClientFactory.CreateClient();
            //var jsonData = JsonConvert.SerializeObject(updateAboutDTO);
            //StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            //var response = await client.PutAsync("http://localhost:7070/api/Abouts", content);
            //if (response.IsSuccessStatusCode)
            //{
            //    return RedirectToAction("Index", "About", new { area = "Admin" });
            //}
            //return View();

            await _aboutService.UpdateAboutAsync(updateAboutDTO);

            return RedirectToAction("Index", "About", new { area = "Admin" });
        }

        private void AboutViewBagList()
        {
            ViewBag.v1 = "Home Page";
            ViewBag.v2 = "Abouts";
            ViewBag.v3 = "Abouts List";
            ViewBag.v0 = "About operations";
        }
    }
}
