using Microsoft.AspNetCore.Mvc;

namespace MicroMultiBusiness.WebUI.ViewComponents.ProductDetailViewComponent
{
    public class _ProductDetailReviewComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
