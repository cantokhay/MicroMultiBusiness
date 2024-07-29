using MicroMultiBusiness.Catalog.DTOs.SpecialOfferDTOs;

namespace MicroMultiBusiness.Catalog.Services.SpecialOfferServices
{
    public interface ISpecialOfferService
    {
        Task<List<ResultSpecialOfferDTO>> GetAllSpecialOffersAsync();
        Task CreateSpecialOfferAsync(CreateSpecialOfferDTO createSpecialOfferDTO);
        Task UpdateSpecialOfferAsync(UpdateSpecialOfferDTO updateSpecialOfferDTO);
        Task DeleteSpecialOfferAsync(string id);
        Task<GetByIdSpecialOfferDTO> GetByIdSpecialOfferAsync(string id);
    }
}
