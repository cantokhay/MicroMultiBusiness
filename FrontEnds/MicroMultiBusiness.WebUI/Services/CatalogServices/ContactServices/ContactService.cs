using MicroMultiBusiness.DTOLayer.CatalogDTOs.CategoryDTOs;
using MicroMultiBusiness.DTOLayer.CatalogDTOs.ContactDTOs;

namespace MicroMultiBusiness.WebUI.Services.CatalogServices.ContactServices
{
    public class ContactService : IContactService
    {
        private readonly HttpClient _httpClient;

        public ContactService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateContactAsync(CreateContactDTO createContactDTO)
        {
            await _httpClient.PostAsJsonAsync<CreateContactDTO>(requestUri: "contacts", value: createContactDTO);
        }

        public async Task DeleteContactAsync(string id)
        {
            await _httpClient.DeleteAsync("contacts?id=" + id);
        }

        public async Task<List<ResultContactDTO>> GetAllContactsAsync()
        {
            var response = await _httpClient.GetAsync("contacts");
            var valuesList = await response.Content.ReadFromJsonAsync<List<ResultContactDTO>>();
            return valuesList;
        }

        public async Task<UpdateContactDTO> GetByIdContactAsync(string id)
        {
            var response = await _httpClient.GetAsync("contacts/" + id);
            var value = await response.Content.ReadFromJsonAsync<UpdateContactDTO>();
            return value;
        }

        public async Task UpdateContactAsync(UpdateContactDTO updateContactDTO)
        {
            await _httpClient.PutAsJsonAsync<UpdateContactDTO>("contacts", updateContactDTO);
        }
    }
}
