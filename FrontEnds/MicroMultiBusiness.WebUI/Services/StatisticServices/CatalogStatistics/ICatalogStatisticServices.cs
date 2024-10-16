namespace MicroMultiBusiness.WebUI.Services.StatisticServices.CatalogStatistics
{
    public interface ICatalogStatisticServices
    {
        Task<long> GetCategoryCount();
        Task<long> GetProductCount();
        Task<long> GetBrandCount();
        Task<decimal> GetAvgProductPrice();
        Task<string> GetMinPriceProductName();
        Task<string> GetMaxPriceProductName();
    }
}
