using Microsoft.AspNetCore.Mvc;

namespace MicroMultiBusiness.WebUI.ViewComponents.ShoppingCartViewComponents
{
    public class _ShoppingCartDiscountCouponComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View(); //we create another partial view for discount coupon ~/Views/Discount/ConfirmDiscountCoupon.cshtml. Useless
        }
    }
}
