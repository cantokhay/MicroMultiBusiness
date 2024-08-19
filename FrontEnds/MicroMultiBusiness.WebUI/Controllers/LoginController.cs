using MicroMultiBusiness.DTOLayer.IdentityDTOs.LoginDTOs;
using MicroMultiBusiness.WebUI.Models;
using MicroMultiBusiness.WebUI.Services;
using MicroMultiBusiness.WebUI.Services.Abstract;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace MicroMultiBusiness.WebUI.Controllers
{
	public class LoginController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;
		private readonly ILoginService _loginService;
		private readonly IIdentityService _identityService;

        public LoginController(IHttpClientFactory httpClientFactory, ILoginService loginService, IIdentityService identityService)
        {
            _httpClientFactory = httpClientFactory;
            _loginService = loginService;
            _identityService = identityService;
        }

        [HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Index(CreateLoginDTO createLoginDTO)
		{
			var client = _httpClientFactory.CreateClient();
			var content = new StringContent(JsonSerializer.Serialize(createLoginDTO), Encoding.UTF8, "application/json");
			var response = await client.PostAsync("http://localhost:5001/api/Logins", content);
			if (response.IsSuccessStatusCode)
			{
				var jsonData = await response.Content.ReadAsStringAsync();
				var tokenModel = JsonSerializer.Deserialize<JwtResponseModel>(jsonData, new JsonSerializerOptions
				{
					PropertyNamingPolicy = JsonNamingPolicy.CamelCase
				});

				if (tokenModel != null)
				{
					JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
					var token = handler.ReadJwtToken(tokenModel.Token);
					var claims = token.Claims.ToList();

					if (tokenModel.Token != null)
					{
						claims.Add(new Claim("micromultibusinesstoken", tokenModel.Token));
						var claimsIdentity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);
						var authProperties = new AuthenticationProperties
						{
							ExpiresUtc = tokenModel.ExpireDate,
							IsPersistent = true
						};

						await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
						var id = _loginService.GetUserId;
						return RedirectToAction("Index", "Default");
					}
				}
			}
			return View();
		}

		//[HttpGet]
		//public IActionResult SignIn()
		//{
		//	return View();
		//}

		//[HttpPost]
		public async Task<IActionResult> SignIn(SignInDTO signInDTO)
		{
			signInDTO.UserName = "microbusiness";
			signInDTO.Password = "1111aA*";
			await _identityService.SignIn(signInDTO);
            return RedirectToAction("Index", "Test");
        }
	}
}
