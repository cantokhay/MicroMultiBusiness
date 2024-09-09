using MicroMultiBusiness.WebUI.Services.BasketServices;
using Microsoft.AspNetCore.Mvc;

namespace MicroMultiBusiness.WebUI.ViewComponents.OrderViewComponents
{
    public class _SummaryOrderComponentPartial : ViewComponent
    {
        private readonly IBasketService _basketService;

        public _SummaryOrderComponentPartial(IBasketService basketService)
        {
            _basketService = basketService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var basketTotal = await _basketService.GetBasket();
            var values = basketTotal.BasketItems;
            return View(values);
        }
    }
}
