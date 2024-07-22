using Microsoft.AspNetCore.Mvc;

namespace MicroMultiBusiness.WebUI.ViewComponents.ProductDetailViewComponent
{
    public class _ProductDetailInformationComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
