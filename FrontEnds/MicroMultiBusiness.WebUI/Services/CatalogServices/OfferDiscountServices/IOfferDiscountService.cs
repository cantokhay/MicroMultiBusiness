using MicroMultiBusiness.DTOLayer.CatalogDTOs.OfferDiscountDTOs;

namespace MicroMultiBusiness.WebUI.Services.CatalogServices.OfferDiscountServices
{
    public interface IOfferDiscountService
    {
        Task<List<ResultOfferDiscountDTO>> GetAllOfferDiscountsAsync();
        Task CreateOfferDiscountAsync(CreateOfferDiscountDTO createOfferDiscountDTO);
        Task UpdateOfferDiscountAsync(UpdateOfferDiscountDTO updateOfferDiscountDTO);
        Task DeleteOfferDiscountAsync(string id);
        Task<UpdateOfferDiscountDTO> GetByIdOfferDiscountAsync(string id);
    }
}
