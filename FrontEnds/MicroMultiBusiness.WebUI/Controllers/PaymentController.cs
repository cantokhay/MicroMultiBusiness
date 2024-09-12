using Microsoft.AspNetCore.Mvc;

namespace MicroMultiBusiness.WebUI.Controllers
{
    public class PaymentController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Directory1 = "Home Page";
            ViewBag.Directory2 = "Payment";
            ViewBag.Directory3 = "Credit / Debit";
            return View();
        }
    }
}
