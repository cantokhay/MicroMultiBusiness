using MicroMultiBusiness.Discount.DTOs;

namespace MicroMultiBusiness.Discount.Services
{
    public interface IDiscountService
    {
        Task<List<ResultDiscountCouponDTO>> GetAllDiscountCouponsAsync();
        Task CreateDiscountCouponAsync(CreateDiscountCouponDTO createCouponDTO);
        Task UpdateDiscountCouponAsync(UpdateDiscountCouponDTO updateCouponDTO);
        Task DeleteDiscountCouponAsync(int id);
        Task<GetByIdDiscountCouponDTO> GetByIdDiscountCouponAsync(int id);
    }
}
