using MicroMultiBusiness.DTOLayer.CatalogDTOs.SpecialOfferDTOs;
using MicroMultiBusiness.WebUI.Services.CatalogServices.SpecialOfferServices;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Authorization;
//using Newtonsoft.Json;
//using System.Text;

namespace MicroMultiBusiness.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[AllowAnonymous]
    [Route("Admin/SpecialOffer")]
    public class SpecialOfferController : Controller
    {
        //private readonly IHttpClientFactory _httpClientFactory;
        private readonly ISpecialOfferService _specialOfferService;

        public SpecialOfferController(ISpecialOfferService specialOfferService)
        {
            //_httpClientFactory = httpClientFactory;
            _specialOfferService = specialOfferService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            SpecialOfferViewBagList();

            //var client = _httpClientFactory.CreateClient();
            //var response = await client.GetAsync("http://localhost:7070/api/SpecialOffers");
            //if (response.IsSuccessStatusCode)
            //{
            //    var jsonData = await response.Content.ReadAsStringAsync();
            //    var valuesList = JsonConvert.DeserializeObject<List<ResultSpecialOfferDTO>>(jsonData);
            //    return View(valuesList);
            //}
            //return View();

            var valuesList = await _specialOfferService.GetAllSpecialOffersAsync();

            return View(valuesList);
        }

        [HttpGet]
        [Route("CreateSpecialOffer")]
        public IActionResult CreateSpecialOffer()
        {
            SpecialOfferViewBagList();

            return View();
        }

        [HttpPost]
        [Route("CreateSpecialOffer")]
        public async Task<IActionResult> CreateSpecialOffer(CreateSpecialOfferDTO createSpecialOfferDTO)
        {
            //var client = _httpClientFactory.CreateClient();
            //var jsonData = JsonConvert.SerializeObject(createSpecialOfferDTO);
            //StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            //var response = await client.PostAsync("http://localhost:7070/api/SpecialOffers", content);
            //if (response.IsSuccessStatusCode)
            //{
            //    return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });
            //}
            //return View();

            await _specialOfferService.CreateSpecialOfferAsync(createSpecialOfferDTO);

            return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });
        }

        [Route("DeleteSpecialOffer/{id}")]
        public async Task<IActionResult> DeleteSpecialOffer(string id)
        {
            //var client = _httpClientFactory.CreateClient();
            //var response = await client.DeleteAsync("http://localhost:7070/api/SpecialOffers?id=" + id);
            //if (response.IsSuccessStatusCode)
            //{
            //    return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });
            //}
            //return View();

            await _specialOfferService.DeleteSpecialOfferAsync(id);

            return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });
        }

        [Route("UpdateSpecialOffer/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateSpecialOffer(string id)
        {
            SpecialOfferViewBagList();

            //var client = _httpClientFactory.CreateClient();
            //var response = await client.GetAsync("http://localhost:7070/api/SpecialOffers/" + id);
            //if (response.IsSuccessStatusCode)
            //{
            //    var jsonData = await response.Content.ReadAsStringAsync();
            //    var valueToUpdate = JsonConvert.DeserializeObject<UpdateSpecialOfferDTO>(jsonData);
            //    return View(valueToUpdate);
            //}
            //return View();

            var valueToUpdate = await _specialOfferService.GetByIdSpecialOfferAsync(id);

            return View(valueToUpdate);
        }

        [Route("UpdateSpecialOffer/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateSpecialOffer(UpdateSpecialOfferDTO updateSpecialOfferDTO)
        {
            //var client = _httpClientFactory.CreateClient();
            //var jsonData = JsonConvert.SerializeObject(updateSpecialOfferDTO);
            //StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            //var response = await client.PutAsync("http://localhost:7070/api/SpecialOffers", content);
            //if (response.IsSuccessStatusCode)
            //{
            //    return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });
            //}
            //return View();

            await _specialOfferService.UpdateSpecialOfferAsync(updateSpecialOfferDTO);

            return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });
        }

        private void SpecialOfferViewBagList()
        {
            ViewBag.v1 = "Home Page";
            ViewBag.v2 = "SpecialOffers";
            ViewBag.v3 = "SpecialOffers List";
            ViewBag.v0 = "SpecialOffer operations";
        }
    }
}
