using MicroMultiBusiness.DTOLayer.CatalogDTOs.ProductImageDTOs;

namespace MicroMultiBusiness.WebUI.Services.CatalogServices.ProductImageServices
{
    public class ProductImageService : IProductImageService
    {
        private readonly HttpClient _httpClient;

        public ProductImageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateProductImageAsync(CreateProductImageDTO createProductImageDTO)
        {
            await _httpClient.PostAsJsonAsync<CreateProductImageDTO>(requestUri: "ProductImages", createProductImageDTO);
        }

        public async Task DeleteProductImageAsync(string id)
        {
            await _httpClient.DeleteAsync("ProductImages?id=" + id);
        }

        public async Task<List<ResultProductImageDTO>> GetAllProductImagesAsync()
        {
            var response = await _httpClient.GetAsync("ProductImages");
            var valuesList = await response.Content.ReadFromJsonAsync<List<ResultProductImageDTO>>();
            return valuesList;
        }

        public async Task<GetByIdProductImageDTO> GetAllProductImagesByProductIdAsync(string id)
        {
            var response = await _httpClient.GetAsync("ProductImages/ProductImagesByProductId/" + id);
            var valuesList = await response.Content.ReadFromJsonAsync<GetByIdProductImageDTO>();
            return valuesList;
        }

        public async Task<GetByIdProductImageDTO> GetByIdProductImageAsync(string id)
        {
            var response = await _httpClient.GetAsync("ProductImages/" + id);
            var value = await response.Content.ReadFromJsonAsync<GetByIdProductImageDTO>();
            return value;
        }

        public async Task UpdateProductImageAsync(UpdateProductImageDTO updateProductImageDTO)
        {
            await _httpClient.PutAsJsonAsync<UpdateProductImageDTO>("ProductImages", updateProductImageDTO);
        }
    }
}
