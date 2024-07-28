using MicroMultiBusiness.Catalog.DTOs.FeatureSliderDTOs;

namespace MicroMultiBusiness.Catalog.Services.FeatureSliderServices
{
    public interface IFeatureSliderService
    {
        Task<List<ResultFeatureSliderDTO>> GetAllFeatureSlidersAsync();
        Task CreateFeatureSliderAsync(CreateFeatureSliderDTO createFeatureSliderDTO);
        Task UpdateFeatureSliderAsync(UpdateFeatureSliderDTO updateFeatureSliderDTO);
        Task DeleteFeatureSliderAsync(string id);
        Task<GetByIdFeatureSliderDTO> GetByIdFeatureSliderAsync(string id);
        Task FeatureSliderStatusTrue(string id);
        Task FeatureSliderStatusFalse(string id);
    }
}
