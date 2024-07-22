using Microsoft.AspNetCore.Mvc;

namespace MicroMultiBusiness.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _ScriptUILayoutComponenetPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
