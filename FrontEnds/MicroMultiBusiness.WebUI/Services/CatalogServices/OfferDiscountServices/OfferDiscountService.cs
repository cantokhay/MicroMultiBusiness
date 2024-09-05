using MicroMultiBusiness.DTOLayer.CatalogDTOs.OfferDiscountDTOs;

namespace MicroMultiBusiness.WebUI.Services.CatalogServices.OfferDiscountServices
{
    public class OfferDiscountService : IOfferDiscountService
    {
        private readonly HttpClient _httpClient;

        public OfferDiscountService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateOfferDiscountAsync(CreateOfferDiscountDTO createOfferDiscountDTO)
        {
            await _httpClient.PostAsJsonAsync<CreateOfferDiscountDTO>("offerdiscounts", createOfferDiscountDTO);
        }

        public async Task DeleteOfferDiscountAsync(string id)
        {
            await _httpClient.DeleteAsync("offerdiscounts?id=" + id);
        }

        public async Task<List<ResultOfferDiscountDTO>> GetAllOfferDiscountsAsync()
        {
            var response = await _httpClient.GetAsync("offerdiscounts");
            var valuesList = await response.Content.ReadFromJsonAsync<List<ResultOfferDiscountDTO>>();
            return valuesList;
        }

        public async Task<UpdateOfferDiscountDTO> GetByIdOfferDiscountAsync(string id)
        {
            var response = await _httpClient.GetAsync("offerdiscounts/" + id);
            var value = await response.Content.ReadFromJsonAsync<UpdateOfferDiscountDTO>();
            return value;
        }

        public async Task UpdateOfferDiscountAsync(UpdateOfferDiscountDTO updateOfferDiscountDTO)
        {
            await _httpClient.PutAsJsonAsync<UpdateOfferDiscountDTO>("offerdiscounts", updateOfferDiscountDTO);
        }
    }
}
