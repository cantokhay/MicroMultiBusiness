using MicroMultiBusiness.DTOLayer.CatalogDTOs.OfferDiscountDTOs;
using MicroMultiBusiness.WebUI.Services.CatalogServices.OfferDiscountServices;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Authorization;
//using Newtonsoft.Json;
//using System.Text;

namespace MicroMultiBusiness.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[AllowAnonymous]
    [Route("Admin/OfferDiscount")]
    public class OfferDiscountController : Controller
    {
        //private readonly IHttpClientFactory _httpClientFactory;
        private readonly IOfferDiscountService _offerDiscountService;

        public OfferDiscountController(IOfferDiscountService offerDiscountService)
        {
            //_httpClientFactory = httpClientFactory;
            _offerDiscountService = offerDiscountService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            OfferDiscountViewBagList();

            //var client = _httpClientFactory.CreateClient();
            //var response = await client.GetAsync("http://localhost:7070/api/OfferDiscounts");
            //if (response.IsSuccessStatusCode)
            //{
            //    var jsonData = await response.Content.ReadAsStringAsync();
            //    var valuesList = JsonConvert.DeserializeObject<List<ResultOfferDiscountDTO>>(jsonData);
            //    return View(valuesList);
            //}
            //return View();

            var valuesList = await _offerDiscountService.GetAllOfferDiscountsAsync();

            return View(valuesList);
        }

        [HttpGet]
        [Route("CreateOfferDiscount")]
        public IActionResult CreateOfferDiscount()
        {
            OfferDiscountViewBagList();

            return View();
        }

        [HttpPost]
        [Route("CreateOfferDiscount")]
        public async Task<IActionResult> CreateOfferDiscount(CreateOfferDiscountDTO createOfferDiscountDTO)
        {
            //var client = _httpClientFactory.CreateClient();
            //var jsonData = JsonConvert.SerializeObject(createOfferDiscountDTO);
            //StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            //var response = await client.PostAsync("http://localhost:7070/api/OfferDiscounts", content);
            //if (response.IsSuccessStatusCode)
            //{
            //    return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });
            //}
            //return View();

            await _offerDiscountService.CreateOfferDiscountAsync(createOfferDiscountDTO);

            return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });
        }

        [Route("DeleteOfferDiscount/{id}")]
        public async Task<IActionResult> DeleteOfferDiscount(string id)
        {
            //var client = _httpClientFactory.CreateClient();
            //var response = await client.DeleteAsync("http://localhost:7070/api/OfferDiscounts?id=" + id);
            //if (response.IsSuccessStatusCode)
            //{
            //    return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });
            //}
            //return View();

            await _offerDiscountService.DeleteOfferDiscountAsync(id);

            return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });
        }

        [Route("UpdateOfferDiscount/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateOfferDiscount(string id)
        {
            OfferDiscountViewBagList();

            //var client = _httpClientFactory.CreateClient();
            //var response = await client.GetAsync("http://localhost:7070/api/OfferDiscounts/" + id);
            //if (response.IsSuccessStatusCode)
            //{
            //    var jsonData = await response.Content.ReadAsStringAsync();
            //    var valueToUpdate = JsonConvert.DeserializeObject<UpdateOfferDiscountDTO>(jsonData);
            //    return View(valueToUpdate);
            //}
            //return View();

            var valueToUpdate = await _offerDiscountService.GetByIdOfferDiscountAsync(id);

            return View(valueToUpdate);
        }

        [Route("UpdateOfferDiscount/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateOfferDiscount(UpdateOfferDiscountDTO updateOfferDiscountDTO)
        {
            //var client = _httpClientFactory.CreateClient();
            //var jsonData = JsonConvert.SerializeObject(updateOfferDiscountDTO);
            //StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            //var response = await client.PutAsync("http://localhost:7070/api/OfferDiscounts", content);
            //if (response.IsSuccessStatusCode)
            //{
            //    return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });
            //}
            //return View();

            await _offerDiscountService.UpdateOfferDiscountAsync(updateOfferDiscountDTO);

            return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });
        }

        private void OfferDiscountViewBagList()
        {
            ViewBag.v1 = "Home Page";
            ViewBag.v2 = "Offer Discount";
            ViewBag.v3 = "Offer Discount List";
            ViewBag.v0 = "Offer Discount operations";
        }
    }
}
