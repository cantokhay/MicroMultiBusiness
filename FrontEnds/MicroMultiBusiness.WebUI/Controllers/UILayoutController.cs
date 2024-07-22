using Microsoft.AspNetCore.Mvc;

namespace MicroMultiBusiness.WebUI.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult _UILayout()
        {
            return View();
        }
    }
}
