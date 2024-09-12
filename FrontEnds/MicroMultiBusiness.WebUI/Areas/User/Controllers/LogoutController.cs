using Microsoft.AspNetCore.Mvc;

namespace MicroMultiBusiness.WebUI.Areas.User.Controllers
{
    public class LogoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
