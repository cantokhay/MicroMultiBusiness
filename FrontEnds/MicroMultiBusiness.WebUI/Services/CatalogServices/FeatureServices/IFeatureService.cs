using MicroMultiBusiness.DTOLayer.CatalogDTOs.FeatureDTOs;

namespace MicroMultiBusiness.WebUI.Services.CatalogServices.FeatureServices
{
    public interface IFeatureService
    {
        Task<List<ResultFeatureDTO>> GetAllFeaturesAsync();
        Task CreateFeatureAsync(CreateFeatureDTO createFeatureDTO);
        Task UpdateFeatureAsync(UpdateFeatureDTO updateFeatureDTO);
        Task DeleteFeatureAsync(string id);
        Task<UpdateFeatureDTO> GetByIdFeatureAsync(string id);
    }
}
