using MicroMultiBusiness.WebUI.Services.BasketServices;
using MicroMultiBusiness.WebUI.Services.DiscountServices;
using Microsoft.AspNetCore.Mvc;

namespace MicroMultiBusiness.WebUI.Controllers
{
    public class DiscountController : Controller
    {
        private readonly IDiscountService _discountService;
        private readonly IBasketService _basketService;

        public DiscountController(IDiscountService discountService, IBasketService basketService)
        {
            _discountService = discountService;
            _basketService = basketService;
        }

        [HttpGet]
        public PartialViewResult ConfirmDiscountCoupon()
        {
            return PartialView();
        }

        //[HttpPost]
        //public async Task<IActionResult> ConfirmDiscountCoupon(string code)
        //{
        //    var coupon = await _discountService.GetDiscountDetailByCouponCode(code);

        //    var basketTotal = await _basketService.GetBasket();
        //    var rate = coupon.Rate;
        //    decimal tax = basketTotal.TotalPrice * 0.18m;
        //    decimal totalWithTax = basketTotal.TotalPrice * 1.18m;
        //    var totalWithDiscount = totalWithTax - (totalWithTax * coupon.Rate / 100);

        //    return RedirectToAction("Index","ShoppingCart", new { code = code, discountRate = rate, totalWithDiscount = totalWithDiscount });
        //}

        [HttpPost]
        public async Task<IActionResult> ConfirmDiscountCoupon(string code)
        {
            var coupon = await _discountService.GetDiscountDetailByCouponCode(code);

            if (coupon == null)
            {
                return RedirectToAction("Index", "ShoppingCart"); // Return the original view with an error
            }

            var basketTotal = await _basketService.GetBasket();
            var rate = coupon.Rate;
            decimal tax = basketTotal.TotalPrice * 0.18m;
            decimal totalWithTax = basketTotal.TotalPrice * 1.18m;
            var totalWithDiscount = totalWithTax - (totalWithTax * coupon.Rate / 100);

            return RedirectToAction("Index", "ShoppingCart", new { code = code, discountRate = rate, totalWithDiscount = totalWithDiscount });
        }
    }
}
