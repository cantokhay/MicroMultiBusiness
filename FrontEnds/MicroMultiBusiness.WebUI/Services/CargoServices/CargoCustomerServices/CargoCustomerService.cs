using MicroMultiBusiness.DTOLayer.CargoDTOs.CargoCustomerDTOs;

namespace MicroMultiBusiness.WebUI.Services.CargoServices.CargoCustomerServices
{
    public class CargoCustomerService : ICargoCustomerService
    {
        private readonly HttpClient _httpClient;

        public CargoCustomerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<GetCargoCustomerByIdDTO> GetCargoCustomerDetailByIdAsync(string id)
        {
            var response = await _httpClient.GetAsync("cargocustomers/GetCustomerByUserId?id=" + id);
            var value = await response.Content.ReadFromJsonAsync<GetCargoCustomerByIdDTO>();
            return value;
        }
    }
}
