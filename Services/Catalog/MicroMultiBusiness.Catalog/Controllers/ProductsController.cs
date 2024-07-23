using MicroMultiBusiness.Catalog.DTOs.ProductDTOs;
using MicroMultiBusiness.Catalog.Services.ProductServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MicroMultiBusiness.Catalog.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productsService;

        public ProductsController(IProductService productsService)
        {
            _productsService = productsService;
        }

        [HttpGet]
        public async Task<IActionResult> ProductList()
        {
            var products = await _productsService.GetAllProductsAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(string id)
        {
            var product = await _productsService.GetByIdProductAsync(id);
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDTO createProductDTO)
        {
            await _productsService.CreateProductAsync(createProductDTO);
            return Ok("Created Succesfully");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            await _productsService.DeleteProductAsync(id);
            return Ok("Deleted Succesfully");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductDTO updateProductDTO)
        {
            await _productsService.UpdateProductAsync(updateProductDTO);
            return Ok("Updated Succesfully");
        }
    }
}
