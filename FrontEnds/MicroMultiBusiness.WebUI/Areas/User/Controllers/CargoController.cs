using Microsoft.AspNetCore.Mvc;

namespace MicroMultiBusiness.WebUI.Areas.User.Controllers
{
    public class CargoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
