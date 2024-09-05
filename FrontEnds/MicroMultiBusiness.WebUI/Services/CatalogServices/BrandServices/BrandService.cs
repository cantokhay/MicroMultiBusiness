using MicroMultiBusiness.DTOLayer.CatalogDTOs.BrandDTOs;

namespace MicroMultiBusiness.WebUI.Services.CatalogServices.BrandServices
{
    public class BrandService : IBrandService
    {
        private readonly HttpClient _httpClient;

        public BrandService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateBrandAsync(CreateBrandDTO createBrandDTO)
        {
            await _httpClient.PostAsJsonAsync<CreateBrandDTO>("brands", createBrandDTO);
        }

        public async Task DeleteBrandAsync(string id)
        {
            await _httpClient.DeleteAsync("brands?id=" + id);
        }

        public async Task<List<ResultBrandDTO>> GetAllBrandsAsync()
        {
            var response = await _httpClient.GetAsync("brands");
            var valuesList = await response.Content.ReadFromJsonAsync<List<ResultBrandDTO>>();
            return valuesList;
        }

        public async Task<UpdateBrandDTO> GetByIdBrandAsync(string id)
        {
            var response = await _httpClient.GetAsync("brands/" + id);
            var value = await response.Content.ReadFromJsonAsync<UpdateBrandDTO>();
            return value;
        }

        public async Task UpdateBrandAsync(UpdateBrandDTO updateBrandDTO)
        {
            await _httpClient.PutAsJsonAsync<UpdateBrandDTO>("brands", updateBrandDTO);
        }
    }
}
