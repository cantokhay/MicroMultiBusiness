using MicroMultiBusiness.DTOLayer.CatalogDTOs.SpecialOfferDTOs;

namespace MicroMultiBusiness.WebUI.Services.CatalogServices.SpecialOfferServices
{
    public class SpecialOfferService : ISpecialOfferService
    {
        private readonly HttpClient _httpClient;

        public SpecialOfferService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateSpecialOfferAsync(CreateSpecialOfferDTO createSpecialOfferDTO)
        {
            await _httpClient.PostAsJsonAsync<CreateSpecialOfferDTO>("specialOffers", createSpecialOfferDTO);
        }

        public async Task DeleteSpecialOfferAsync(string id)
        {
            await _httpClient.DeleteAsync("specialOffers?id=" + id);
        }

        public async Task<List<ResultSpecialOfferDTO>> GetAllSpecialOffersAsync()
        {
            var response = await _httpClient.GetAsync("specialOffers");
            var valuesList = await response.Content.ReadFromJsonAsync<List<ResultSpecialOfferDTO>>();
            return valuesList;
        }

        public async Task<UpdateSpecialOfferDTO> GetByIdSpecialOfferAsync(string id)
        {
            var response = await _httpClient.GetAsync("specialOffers/" + id);
            var value = await response.Content.ReadFromJsonAsync<UpdateSpecialOfferDTO>();
            return value;
        }

        public async Task UpdateSpecialOfferAsync(UpdateSpecialOfferDTO updateSpecialOfferDTO)
        {
            await _httpClient.PutAsJsonAsync<UpdateSpecialOfferDTO>("specialOffers", updateSpecialOfferDTO);
        }
    }
}
