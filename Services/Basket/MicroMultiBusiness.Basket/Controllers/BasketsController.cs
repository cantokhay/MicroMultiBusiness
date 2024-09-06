using MicroMultiBusiness.Basket.DTOs;
using MicroMultiBusiness.Basket.LoginServices;
using MicroMultiBusiness.Basket.Services;
using Microsoft.AspNetCore.Mvc;

namespace MicroMultiBusiness.Basket.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly ILoginService _loginService;

        public BasketsController(IBasketService basketService, ILoginService loginService)
        {
            _basketService = basketService;
            _loginService = loginService;
        }

        [HttpGet]
        public async Task<IActionResult> GetMyBasketDetail()
        {
            var user = User.Claims;
            var values = await _basketService.GetBasket(_loginService.GetUserId);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> SaveMyBasket(BasketTotalDTO basketTotalDTO)
        {
            basketTotalDTO.UserId = _loginService.GetUserId;
            await _basketService.SaveBasket(basketTotalDTO);
            return Ok("Changes saved successfully");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMyBasket()
        {
            await _basketService.DeleteBasket(_loginService.GetUserId);
            return Ok("Basket deleted successfully");
        }
    }
}
