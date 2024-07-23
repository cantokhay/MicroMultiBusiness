using MicroMultiBusiness.Catalog.DTOs.CategoryDTOs;
using MicroMultiBusiness.Catalog.Services.CategoryServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MicroMultiBusiness.Catalog.Controllers
{
    //[Authorize]
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoriesService;

        public CategoriesController(ICategoryService categoriesService)
        {
            _categoriesService = categoriesService;
        }

        [HttpGet]
        public async Task<IActionResult> CategoryList()
        {
            var categories = await _categoriesService.GetAllCategoriesAsync();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(string id)
        {
            var category = await _categoriesService.GetByIdCategoryAsync(id);
            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDTO createCategoryDTO)
        {
            await _categoriesService.CreateCategoryAsync(createCategoryDTO);
            return Ok("Created Succesfully");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(string id)
        {
            await _categoriesService.DeleteCategoryAsync(id);
            return Ok("Deleted Succesfully");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDTO updateCategoryDTO)
        {
            await _categoriesService.UpdateCategoryAsync(updateCategoryDTO);
            return Ok("Updated Succesfully");
        }
    }
}
