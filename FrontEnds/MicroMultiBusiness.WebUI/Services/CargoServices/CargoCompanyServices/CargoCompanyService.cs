using MicroMultiBusiness.DTOLayer.CargoDTOs.CargoCompanyDTOs;

namespace MicroMultiBusiness.WebUI.Services.CargoServices.CargoCompanyServices
{
    public class CargoCompanyService : ICargoCompanyService
    {
        private readonly HttpClient _httpClient;

        public CargoCompanyService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateCargoCompanyAsync(CreateCargoCompanyDTO createCargoCompanyDTO)
        {
            await _httpClient.PostAsJsonAsync<CreateCargoCompanyDTO>("cargocompanies", createCargoCompanyDTO);
        }

        public async Task DeleteCargoCompanyAsync(int id)
        {
            await _httpClient.DeleteAsync("cargocompanies?id=" + id);
        }

        public async Task<List<ResultCargoCompanyDTO>> GetAllCargoCompaniesAsync()
        {
            var response = await _httpClient.GetAsync("cargocompanies");
            var valueList = await response.Content.ReadFromJsonAsync<List<ResultCargoCompanyDTO>>();
            return valueList;
        }

        public async Task<UpdateCargoCompanyDTO> GetByIdCargoCompanyAsync(int id)
        {
            var response = await _httpClient.GetAsync("cargocompanies/" + id);
            var value = await response.Content.ReadFromJsonAsync<UpdateCargoCompanyDTO>();
            return value;
        }

        public async Task UpdateCargoCompanyAsync(UpdateCargoCompanyDTO updateCargoCompanyDTO)
        {
            await _httpClient.PutAsJsonAsync<UpdateCargoCompanyDTO>("cargocompanies", updateCargoCompanyDTO);
        }
    }
}
