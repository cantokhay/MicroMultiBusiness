using Microsoft.AspNetCore.Mvc;

namespace MicroMultiBusiness.WebUI.Areas.User.ViewComponents.UserLayoutViewComponents
{
    public class _UserLayoutNavBarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
