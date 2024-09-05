using MicroMultiBusiness.DTOLayer.CatalogDTOs.FeatureDTOs;

namespace MicroMultiBusiness.WebUI.Services.CatalogServices.FeatureServices
{
    public class FeatureService : IFeatureService
    {
        private readonly HttpClient _httpClient;

        public FeatureService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateFeatureAsync(CreateFeatureDTO createFeatureDTO)
        {
            await _httpClient.PostAsJsonAsync<CreateFeatureDTO>("features", createFeatureDTO);
        }

        public async Task DeleteFeatureAsync(string id)
        {
            await _httpClient.DeleteAsync("features?id=" + id);
        }

        public async Task<List<ResultFeatureDTO>> GetAllFeaturesAsync()
        {
            var response = await _httpClient.GetAsync("features");
            var valuesList = await response.Content.ReadFromJsonAsync<List<ResultFeatureDTO>>();
            return valuesList;
        }

        public async Task<UpdateFeatureDTO> GetByIdFeatureAsync(string id)
        {
            var response = await _httpClient.GetAsync("features/" + id);
            var value = await response.Content.ReadFromJsonAsync<UpdateFeatureDTO>();
            return value;
        }

        public async Task UpdateFeatureAsync(UpdateFeatureDTO updateFeatureDTO)
        {
            await _httpClient.PutAsJsonAsync<UpdateFeatureDTO>("features", updateFeatureDTO);
        }
    }
}
