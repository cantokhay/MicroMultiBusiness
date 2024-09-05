using MicroMultiBusiness.DTOLayer.CatalogDTOs.AboutDTOs;

namespace MicroMultiBusiness.WebUI.Services.CatalogServices.AboutServices
{
    public class AboutService : IAboutService
    {
        private readonly HttpClient _httpClient;

        public AboutService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateAboutAsync(CreateAboutDTO createAboutDTO)
        {
            await _httpClient.PostAsJsonAsync<CreateAboutDTO>("abouts", createAboutDTO);
        }

        public async Task DeleteAboutAsync(string id)
        {
            await _httpClient.DeleteAsync("abouts?id=" + id);
        }

        public async Task<List<ResultAboutDTO>> GetAllAboutsAsync()
        {
            var response = await _httpClient.GetAsync("abouts");
            var valuesList = await response.Content.ReadFromJsonAsync<List<ResultAboutDTO>>();
            return valuesList;
        }

        public async Task<UpdateAboutDTO> GetByIdAboutAsync(string id)
        {
            var response = await _httpClient.GetAsync("abouts/" + id);
            var value = await response.Content.ReadFromJsonAsync<UpdateAboutDTO>();
            return value;
        }

        public async Task UpdateAboutAsync(UpdateAboutDTO updateAboutDTO)
        {
            await _httpClient.PutAsJsonAsync<UpdateAboutDTO>("abouts", updateAboutDTO);
        }
    }
}
