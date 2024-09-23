using MicroMultiBusiness.WebUI.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace MicroMultiBusiness.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> UsersList()
        {
            var valuesList = await _userService.GetUsersList();
            return View(valuesList);
        }
    }
}
