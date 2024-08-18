using MicroMultiBusiness.DTOLayer.IdentityDTOs.RegisterDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace MicroMultiBusiness.WebUI.Controllers
{
	public class RegisterController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public RegisterController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Index(CreateRegisterDTO createRegisterDTO)
		{
			if (createRegisterDTO.Password == createRegisterDTO.ConfirmPassword)
			{
				var client = _httpClientFactory.CreateClient();
				var jsonData = JsonConvert.SerializeObject(createRegisterDTO);
				StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
				var response = await client.PostAsync("http://localhost:5001/api/Registers", content);
				if (response.IsSuccessStatusCode)
				{
					return RedirectToAction("Index", "Login");
				}
			}
			return View();
		}
	}
}
