using MicroMultiBusiness.Catalog.DTOs.FeatureDTOs;

namespace MicroMultiBusiness.Catalog.Services.FeatureServices
{
    public interface IFeatureService
    {
        Task<List<ResultFeatureDTO>> GetAllFeaturesAsync();
        Task CreateFeatureAsync(CreateFeatureDTO createFeatureDTO);
        Task UpdateFeatureAsync(UpdateFeatureDTO updateFeatureDTO);
        Task DeleteFeatureAsync(string id);
        Task<GetByIdFeatureDTO> GetByIdFeatureAsync(string id);
    }
}
