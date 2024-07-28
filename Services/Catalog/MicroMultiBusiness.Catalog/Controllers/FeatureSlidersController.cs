using MicroMultiBusiness.Catalog.DTOs.FeatureSliderDTOs;
using MicroMultiBusiness.Catalog.Services.FeatureSliderServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MicroMultiBusiness.Catalog.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureSlidersController : ControllerBase
    {
        private readonly IFeatureSliderService _featureSliderService;

        public FeatureSlidersController(IFeatureSliderService featureSlidersService)
        {
            _featureSliderService = featureSlidersService;
        }

        [HttpGet]
        public async Task<IActionResult> FeatureSliderList()
        {
            var valueList = await _featureSliderService.GetAllFeatureSlidersAsync();
            return Ok(valueList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFeatureSliderById(string id)
        {
            var value = await _featureSliderService.GetByIdFeatureSliderAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFeatureSlider(CreateFeatureSliderDTO createFeatureSliderDTO)
        {
            await _featureSliderService.CreateFeatureSliderAsync(createFeatureSliderDTO);
            return Ok("Created Succesfully");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteFeatureSlider(string id)
        {
            await _featureSliderService.DeleteFeatureSliderAsync(id);
            return Ok("Deleted Succesfully");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFeatureSlider(UpdateFeatureSliderDTO updateFeatureSliderDTO)
        {
            await _featureSliderService.UpdateFeatureSliderAsync(updateFeatureSliderDTO);
            return Ok("Updated Succesfully");
        }
    }
}
