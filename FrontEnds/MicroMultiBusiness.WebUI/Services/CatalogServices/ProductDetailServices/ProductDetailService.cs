using MicroMultiBusiness.DTOLayer.CatalogDTOs.ProductDetailDTOs;

namespace MicroMultiBusiness.WebUI.Services.CatalogServices.ProductDetailServices
{
    public class ProductDetailService : IProductDetailService
    {
        private readonly HttpClient _httpClient;

        public ProductDetailService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateProductDetailAsync(CreateProductDetailDTO createProductDetailDTO)
        {
            await _httpClient.PostAsJsonAsync<CreateProductDetailDTO>(requestUri: "ProductDetails", createProductDetailDTO);
        }

        public async Task DeleteProductDetailAsync(string id)
        {
            await _httpClient.DeleteAsync("ProductDetails?id=" + id);
        }

        public async Task<List<ResultProductDetailDTO>> GetAllProductDetailsAsync()
        {
            var response = await _httpClient.GetAsync("ProductDetails");
            var valuesList = await response.Content.ReadFromJsonAsync<List<ResultProductDetailDTO>>();
            return valuesList;
        }

        public async Task<GetByIdProductDetailDTO> GetByIdProductDetailAsync(string id)
        {
            var response = await _httpClient.GetAsync("ProductDetails/" + id);
            var value = await response.Content.ReadFromJsonAsync<GetByIdProductDetailDTO>();
            return value;
        }

        public async Task<GetByIdProductDetailDTO> GetByProductIdProductDetailAsync(string id)
        {
            var response = await _httpClient.GetAsync("ProductDetails/GetProductDetailByProductId/" + id);
            var value = await response.Content.ReadFromJsonAsync<GetByIdProductDetailDTO>();
            return value;
        }

        public async Task UpdateProductDetailAsync(UpdateProductDetailDTO updateProductDetailDTO)
        {
            await _httpClient.PutAsJsonAsync<UpdateProductDetailDTO>("ProductDetails", updateProductDetailDTO);
        }
    }
}
