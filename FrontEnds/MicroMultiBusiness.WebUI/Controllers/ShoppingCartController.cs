using MicroMultiBusiness.DTOLayer.BasketDTOs;
using MicroMultiBusiness.WebUI.Services.BasketServices;
using MicroMultiBusiness.WebUI.Services.CatalogServices.ProductServices;
using Microsoft.AspNetCore.Mvc;

namespace MicroMultiBusiness.WebUI.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IBasketService _basketService;
        private readonly IProductService _productService;

        public ShoppingCartController(IBasketService basketService, IProductService productService)
        {
            _basketService = basketService;
            _productService = productService;
        }

        public IActionResult Index()
        {
            ViewBag.Directory1 = "Home Page";
            ViewBag.Directory2 = "Shopping Cart";
            ViewBag.Directory3 = "Buy Now!";
            return View();
        }

        public async Task<IActionResult> AddBasketItem(string id)
        {
            var product = await _productService.GetByIdProductAsync(id);
            var basketItemDTO = new BasketItemDTO
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                Price = product.ProductPrice,
                Quantity = 1,
                ProductImageURL = product.ProductImageUrl
            };
            await _basketService.AddBasketItem(basketItemDTO);
            return RedirectToAction("Index", "ShoppingCart");
        }

        public async Task<IActionResult> RemoveBasketItem(string id)
        {
            await _basketService.RemoveBasketItem(id);
            return RedirectToAction("Index", "ShoppingCart");
        }
    }
}
