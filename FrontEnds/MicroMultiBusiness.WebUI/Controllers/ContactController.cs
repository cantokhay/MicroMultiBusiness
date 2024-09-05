using MicroMultiBusiness.DTOLayer.CatalogDTOs.ContactDTOs;
using MicroMultiBusiness.WebUI.Services.CatalogServices.ContactServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace MicroMultiBusiness.WebUI.Controllers
{
    public class ContactController : Controller
    {
        //private readonly IHttpClientFactory _httpClientFactory;
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            //_httpClientFactory = httpClientFactory;
            _contactService = contactService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Directory1 = "Home Page";
            ViewBag.Directory2 = "Contact Us";
            ViewBag.Directory3 = "Let us know!";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateContactDTO createContactDTO)
        {
            createContactDTO.IsRead = false;
            createContactDTO.SentDate = DateTime.Now;
            //var client = _httpClientFactory.CreateClient();
            //var jsonData = JsonConvert.SerializeObject(createContactDTO);
            //StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            //var response = await client.PostAsync("http://localhost:7070/api/Contacts", content);
            //if (response.IsSuccessStatusCode)
            //{
            //    return RedirectToAction("Index", "Default");
            //}
            //return View();
            await _contactService.CreateContactAsync(createContactDTO);

            return RedirectToAction("Index", "Default");
        }
    }
}
