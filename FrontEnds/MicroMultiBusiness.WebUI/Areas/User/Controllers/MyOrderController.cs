using MicroMultiBusiness.WebUI.Services.Abstract;
using MicroMultiBusiness.WebUI.Services.OrderServices.OrderingServices;
using Microsoft.AspNetCore.Mvc;

namespace MicroMultiBusiness.WebUI.Areas.User.Controllers
{
    [Area("User")]
    public class MyOrderController : Controller
    {
        private readonly IOrderingService _orderingService;
        private readonly IUserService _userService;

        public MyOrderController(IOrderingService orderingService, IUserService userService)
        {
            _orderingService = orderingService;
            _userService = userService;
        }

        public async Task<IActionResult> MyOrderList()
        {
            var user = await _userService.GetUserInfo();
            var valueList = await _orderingService.GetOrderingsByUserIdAsync(user.Id);
            return View(valueList);
        }
    }
}
