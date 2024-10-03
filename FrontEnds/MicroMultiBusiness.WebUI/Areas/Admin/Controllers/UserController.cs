using MicroMultiBusiness.WebUI.Services.Abstract;
using MicroMultiBusiness.WebUI.Services.CargoServices.CargoCustomerServices;
using Microsoft.AspNetCore.Mvc;

namespace MicroMultiBusiness.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly ICargoCustomerService _cargoCustomerService;

        public UserController(IUserService userService, ICargoCustomerService cargoCustomerService)
        {
            _userService = userService;
            _cargoCustomerService = cargoCustomerService;
        }

        public async Task<IActionResult> UsersList()
        {
            var valuesList = await _userService.GetUsersList();
            return View(valuesList);
        }

        public async Task<IActionResult> GetUserAddressInfo(string id)
        {
            var values = await _cargoCustomerService.GetCargoCustomerDetailByIdAsync(id);
            return View(values);
        }
    }
}
