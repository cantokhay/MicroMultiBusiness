using MicroMultiBusiness.DTOLayer.CatalogDTOs.FeatureSliderDTOs;

namespace MicroMultiBusiness.WebUI.Services.CatalogServices.FeatureSliderServices
{
    public class FeatureSliderService : IFeatureSliderService
    {
        private readonly HttpClient _httpClient;

        public FeatureSliderService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateFeatureSliderAsync(CreateFeatureSliderDTO createFeatureSliderDTO)
        {
            await _httpClient.PostAsJsonAsync<CreateFeatureSliderDTO>("FeatureSliders", createFeatureSliderDTO);
        }

        public async Task DeleteFeatureSliderAsync(string id)
        {
            await _httpClient.DeleteAsync("FeatureSliders?id=" + id);
        }

        public Task FeatureSliderStatusFalse(string id)
        {
            throw new NotImplementedException();
        }

        public Task FeatureSliderStatusTrue(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ResultFeatureSliderDTO>> GetAllFeatureSlidersAsync()
        {
            var response = await _httpClient.GetAsync("FeatureSliders");
            var valuesList = await response.Content.ReadFromJsonAsync<List<ResultFeatureSliderDTO>>();
            return valuesList;
        }

        public async Task<UpdateFeatureSliderDTO> GetByIdFeatureSliderAsync(string id)
        {
            var response = await _httpClient.GetAsync("FeatureSliders/" + id);
            var value = await response.Content.ReadFromJsonAsync<UpdateFeatureSliderDTO>();
            return value;
        }

        public async Task UpdateFeatureSliderAsync(UpdateFeatureSliderDTO updateFeatureSliderDTO)
        {
            await _httpClient.PutAsJsonAsync<UpdateFeatureSliderDTO>("FeatureSliders", updateFeatureSliderDTO);
        }
    }
}
