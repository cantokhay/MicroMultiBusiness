using Microsoft.AspNetCore.Mvc;

namespace MicroMultiBusiness.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _TopBarUILayoutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
