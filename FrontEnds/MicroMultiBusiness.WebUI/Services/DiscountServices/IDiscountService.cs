using MicroMultiBusiness.DTOLayer.DiscountDTOs;

namespace MicroMultiBusiness.WebUI.Services.DiscountServices
{
    public interface IDiscountService
    {
        Task<GetDiscountDetailByCouponCodeDTO> GetDiscountDetailByCouponCode(string code);
    }
}
