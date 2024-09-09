using MicroMultiBusiness.DTOLayer.OrderDTOs.AddressDTOs;

namespace MicroMultiBusiness.WebUI.Services.OrderServices.AddressServices
{
    public class AddressService : IAddressService
    {
        private readonly HttpClient _httpClient;

        public AddressService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CreateAddressDTO> CreateAddressAsync(CreateAddressDTO address)
        {
            await _httpClient.PostAsJsonAsync("addresses", address);
            return address;
        }
    }
}
