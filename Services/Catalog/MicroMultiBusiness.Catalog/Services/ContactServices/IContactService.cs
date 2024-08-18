using MicroMultiBusiness.Catalog.DTOs.ContactDTOs;

namespace MicroMultiBusiness.Catalog.Services.ContactServices
{
    public interface IContactService
    {
        Task<List<ResultContactDTO>> GetAllContactsAsync();
        Task CreateContactAsync(CreateContactDTO createContactDTO);
        Task UpdateContactAsync(UpdateContactDTO updateContactDTO);
        Task DeleteContactAsync(string id);
        Task<GetByIdContactDTO> GetByIdContactAsync(string id);
    }
}
