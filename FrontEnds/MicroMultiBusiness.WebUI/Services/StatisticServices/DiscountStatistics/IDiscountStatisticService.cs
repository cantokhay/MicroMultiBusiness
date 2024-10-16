namespace MicroMultiBusiness.WebUI.Services.StatisticServices.DiscountStatistics
{
    public interface IDiscountStatisticService
    {
        Task<int> GetDiscountCouponCount();
    }
}
