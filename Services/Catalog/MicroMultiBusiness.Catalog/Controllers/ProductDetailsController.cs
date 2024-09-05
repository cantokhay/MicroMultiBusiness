using MicroMultiBusiness.Catalog.DTOs.ProductDetailDTOs;
using MicroMultiBusiness.Catalog.Services.ProductDetailServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MicroMultiBusiness.Catalog.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
    public class ProductDetailsController : ControllerBase
    {
        private readonly IProductDetailService _productDetailsService;

        public ProductDetailsController(IProductDetailService productDetailsService)
        {
            _productDetailsService = productDetailsService;
        }

        [HttpGet]
        public async Task<IActionResult> ProductDetailList()
        {
            var productDetails = await _productDetailsService.GetAllProductDetailsAsync();
            return Ok(productDetails);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductDetailById(string id)
        {
            var productDetail = await _productDetailsService.GetByIdProductDetailAsync(id);
            return Ok(productDetail);
        }

        [HttpGet("GetProductDetailByProductId/{id}")]
        public async Task<IActionResult> GetProductDetailByProductId(string id)
        {
            var productDetail = await _productDetailsService.GetByProductIdProductDetailAsync(id);
            return Ok(productDetail);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductDetail(CreateProductDetailDTO createProductDetailDTO)
        {
            await _productDetailsService.CreateProductDetailAsync(createProductDetailDTO);
            return Ok("Created Succesfully");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProductDetail(string id)
        {
            await _productDetailsService.DeleteProductDetailAsync(id);
            return Ok("Deleted Succesfully");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductDetail(UpdateProductDetailDTO updateProductDetailDTO)
        {
            await _productDetailsService.UpdateProductDetailAsync(updateProductDetailDTO);
            return Ok("Updated Succesfully");
        }
    }
}
