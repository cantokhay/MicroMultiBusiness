using Microsoft.AspNetCore.Mvc;

namespace MicroMultiBusiness.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Directory1 = "Home Page";
            ViewBag.Directory2 = "Product List";
            ViewBag.Directory3 = "Shop Now";
            return View();
        }
    }
}
