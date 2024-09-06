using MicroMultiBusiness.DTOLayer.IdentityDTOs.LoginDTOs;
using MicroMultiBusiness.WebUI.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
namespace MicroMultiBusiness.WebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        //private readonly ILoginService _loginService;
        private readonly IIdentityService _identityService;

        public LoginController(IHttpClientFactory httpClientFactory, IIdentityService identityService)
        {
            _httpClientFactory = httpClientFactory;
            //_loginService = loginService;
            _identityService = identityService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(SignInDTO signInDTO)
        { 
            await _identityService.SignIn(signInDTO);
            return RedirectToAction("Index", "User");
        }

        //[HttpGet]
        //public IActionResult SignIn()
        //{
        //	return View();
        //}

        //[HttpPost]
        //public async Task<IActionResult> SignIn(SignInDTO signInDTO)
        //{
        //	signInDTO.UserName = "microbusiness";
        //	signInDTO.Password = "1111aA*";
        //	await _identityService.SignIn(signInDTO);
        //          return RedirectToAction("Index", "User");
        //}
    }
}
