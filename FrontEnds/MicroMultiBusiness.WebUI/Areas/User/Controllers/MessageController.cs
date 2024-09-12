using Microsoft.AspNetCore.Mvc;

namespace MicroMultiBusiness.WebUI.Areas.User.Controllers
{
    public class MessageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
