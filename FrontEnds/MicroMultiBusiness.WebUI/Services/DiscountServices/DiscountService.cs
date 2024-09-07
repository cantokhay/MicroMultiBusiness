using MicroMultiBusiness.DTOLayer.DiscountDTOs;

namespace MicroMultiBusiness.WebUI.Services.DiscountServices
{
    public class DiscountService : IDiscountService
    {
        private readonly HttpClient _httpClient;

        public DiscountService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        //public async Task<GetDiscountDetailByCouponCodeDTO> GetDiscountDetailByCouponCode(string code)
        //{
        //    var response = await _httpClient.GetAsync("discounts/GetDiscountDetailByCouponCodeAsync?code=" + code); //request goes to microservice api GetDiscountDetailByCouponCodeAsync method
        //    var value = await response.Content.ReadFromJsonAsync<GetDiscountDetailByCouponCodeDTO>();
        //    return value;
        //}

        public async Task<GetDiscountDetailByCouponCodeDTO> GetDiscountDetailByCouponCode(string code)
        {
            var response = await _httpClient.GetAsync("discounts/GetDiscountDetailByCouponCodeAsync?code=" + code);

            if (response.StatusCode == System.Net.HttpStatusCode.NoContent) // 204 No Content
            {
                return null; // No coupon found
            }

            var value = await response.Content.ReadFromJsonAsync<GetDiscountDetailByCouponCodeDTO>();
            return value;
        }
    }
}
