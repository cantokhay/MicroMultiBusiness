using MicroMultiBusiness.DTOLayer.OrderDTOs.AddressDTOs;
using MicroMultiBusiness.WebUI.Services.Abstract;
using MicroMultiBusiness.WebUI.Services.OrderServices.AddressServices;
using Microsoft.AspNetCore.Mvc;

namespace MicroMultiBusiness.WebUI.Controllers
{
    public class OrderController : Controller
    {
        private readonly IAddressService _addressService;
        private readonly IUserService _userService;

        public OrderController(IAddressService addressService, IUserService userService)
        {
            _addressService = addressService;
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Directory1 = "Home Page";
            ViewBag.Directory2 = "Orders";
            ViewBag.Directory3 = "Checkout";

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateAddressDTO createAddressDTO)
        {
            ViewBag.Directory1 = "Home Page";
            ViewBag.Directory2 = "Orders";
            ViewBag.Directory3 = "Checkout";

            var user = await _userService.GetUserInfo();
            createAddressDTO.UserId = user.Id;
            createAddressDTO.Description = "Home";

            await _addressService.CreateAddressAsync(createAddressDTO);

            return RedirectToAction("Index", "Payment");
        }
    }
}
