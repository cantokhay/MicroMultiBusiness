using MicroMultiBusiness.WebUI.Services.StatisticServices.CatalogStatistics;
using MicroMultiBusiness.WebUI.Services.StatisticServices.CommentStatistics;
using MicroMultiBusiness.WebUI.Services.StatisticServices.DiscountStatistics;
using MicroMultiBusiness.WebUI.Services.StatisticServices.MessageStatistics;
using MicroMultiBusiness.WebUI.Services.StatisticServices.UserStatistics;
using Microsoft.AspNetCore.Mvc;

namespace MicroMultiBusiness.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StatisticController : Controller
    {
        private readonly ICatalogStatisticServices _catalogStatisticServices;
        private readonly IUserStatisticService _userStatisticService;
        private readonly ICommentStatisticService _commentStatisticService;
        private readonly IMessageStatisticService _messageStatisticService;
        private readonly IDiscountStatisticService _discountStatisticService;

        public StatisticController(ICatalogStatisticServices catalogStatisticServices, IUserStatisticService userStatisticService, ICommentStatisticService commentStatisticService, IMessageStatisticService messageStatisticService, IDiscountStatisticService discountStatisticService)
        {
            _catalogStatisticServices = catalogStatisticServices;
            _userStatisticService = userStatisticService;
            _commentStatisticService = commentStatisticService;
            _messageStatisticService = messageStatisticService;
            _discountStatisticService = discountStatisticService;
        }

        public async Task<IActionResult> Index()
        {
            long brandCount = await _catalogStatisticServices.GetBrandCount();
            long productCount = await _catalogStatisticServices.GetProductCount();
            long categoryCount = await _catalogStatisticServices.GetCategoryCount();
            //decimal avgProductPrice = await _catalogStatisticServices.GetAvgProductPrice(); //TODO: Fix this from the backend. Services/Catalog/Statistics/GetAvgProductPrice
            string maxPriceProductName = await _catalogStatisticServices.GetMaxPriceProductName(); //TODO: Fix this from the frontend 
            string minPriceProductName = await _catalogStatisticServices.GetMinPriceProductName(); //TODO: Fix this from the frontend
            int userCount = await _userStatisticService.GetUserCount();
            int activeCommentsCount = await _commentStatisticService.GetActiveCommentsCountAsync();
            int passiveCommentsCount = await _commentStatisticService.GetPassiveCommentsCountAsync();
            int totalCommentsCount = await _commentStatisticService.GetTotalCommentsCountAsync();
            int totalMessageCount = await _messageStatisticService.GetTotalMessageCount();
            int discountCouponCount = await _discountStatisticService.GetDiscountCouponCount();

            ViewBag.BrandCount = brandCount;
            ViewBag.ProductCount = productCount;
            ViewBag.CategoryCount = categoryCount;
            //ViewBag.AvgProductPrice = avgProductPrice; //TODO: Fix this from the backend. Services/Catalog/Statistics/GetAvgProductPrice
            ViewBag.MaxPriceProductName = maxPriceProductName; //TODO: Fix this from the frontend
            ViewBag.MinPriceProductName = minPriceProductName; //TODO: Fix this from the frontend
            ViewBag.UserCount = userCount;
            ViewBag.ActiveCommentsCount = activeCommentsCount;
            ViewBag.PassiveCommentsCount = passiveCommentsCount;
            ViewBag.TotalCommentsCount = totalCommentsCount;
            ViewBag.TotalMessageCount = totalMessageCount;
            ViewBag.DiscountCouponCount = discountCouponCount;

            return View();
        }
    }
}
