using MicroMultiBusiness.Catalog.DTOs.BrandDTOs;
using MicroMultiBusiness.Catalog.Services.BrandServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MicroMultiBusiness.Catalog.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet]
        public async Task<IActionResult> BrandList()
        {
            var valueList = await _brandService.GetAllBrandsAsync();
            return Ok(valueList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBrandById(string id)
        {
            var value = await _brandService.GetByIdBrandAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBrand(CreateBrandDTO createBrandDTO)
        {
            await _brandService.CreateBrandAsync(createBrandDTO);
            return Ok("Created Succesfully");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBrand(string id)
        {
            await _brandService.DeleteBrandAsync(id);
            return Ok("Deleted Succesfully");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBrand(UpdateBrandDTO updateBrandDTO)
        {
            await _brandService.UpdateBrandAsync(updateBrandDTO);
            return Ok("Updated Succesfully");
        }
    }
}
