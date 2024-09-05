using MicroMultiBusiness.DTOLayer.CatalogDTOs.SpecialOfferDTOs;

namespace MicroMultiBusiness.WebUI.Services.CatalogServices.SpecialOfferServices
{
    public interface ISpecialOfferService
    {
        Task<List<ResultSpecialOfferDTO>> GetAllSpecialOffersAsync();
        Task CreateSpecialOfferAsync(CreateSpecialOfferDTO createSpecialOfferDTO);
        Task UpdateSpecialOfferAsync(UpdateSpecialOfferDTO updateSpecialOfferDTO);
        Task DeleteSpecialOfferAsync(string id);
        Task<UpdateSpecialOfferDTO> GetByIdSpecialOfferAsync(string id);
    }
}
