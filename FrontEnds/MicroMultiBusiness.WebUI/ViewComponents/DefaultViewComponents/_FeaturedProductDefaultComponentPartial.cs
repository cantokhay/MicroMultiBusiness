using Microsoft.AspNetCore.Mvc;

namespace MicroMultiBusiness.WebUI.ViewComponents.DefaultViewComponents
{
    public class _FeaturedProductDefaultComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
