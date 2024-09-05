using MicroMultiBusiness.DTOLayer.CatalogDTOs.FeatureSliderDTOs;

namespace MicroMultiBusiness.WebUI.Services.CatalogServices.FeatureSliderServices
{
    public interface IFeatureSliderService
    {
        Task<List<ResultFeatureSliderDTO>> GetAllFeatureSlidersAsync();
        Task CreateFeatureSliderAsync(CreateFeatureSliderDTO createFeatureSliderDTO);
        Task UpdateFeatureSliderAsync(UpdateFeatureSliderDTO updateFeatureSliderDTO);
        Task DeleteFeatureSliderAsync(string id);
        Task<UpdateFeatureSliderDTO> GetByIdFeatureSliderAsync(string id);
        Task FeatureSliderStatusTrue(string id);
        Task FeatureSliderStatusFalse(string id);
    }
}
