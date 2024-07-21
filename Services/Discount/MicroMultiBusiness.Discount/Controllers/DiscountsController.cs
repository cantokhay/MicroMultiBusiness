using MicroMultiBusiness.Discount.DTOs;
using MicroMultiBusiness.Discount.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MicroMultiBusiness.Discount.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        private readonly IDiscountService _discountService;

        public DiscountsController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        [HttpGet]
        public async Task<IActionResult> DiscountCouponList()
        {
            var coupons = await _discountService.GetAllDiscountCouponsAsync();
            return Ok(coupons);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDiscountCouponById(int id)
        {
            var coupon = await _discountService.GetByIdDiscountCouponAsync(id);
            return Ok(coupon);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDiscountCoupon(CreateDiscountCouponDTO createCouponDTO)
        {
            await _discountService.CreateDiscountCouponAsync(createCouponDTO);
            return Ok("Created Succesfully");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteDiscountCoupon(int id)
        {
            await _discountService.DeleteDiscountCouponAsync(id);
            return Ok("Deleted Succesfully");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDiscountCoupon(UpdateDiscountCouponDTO updateCouponDTO)
        {
            await _discountService.UpdateDiscountCouponAsync(updateCouponDTO);
            return Ok("Updated Succesfully");
        }
    }
}
