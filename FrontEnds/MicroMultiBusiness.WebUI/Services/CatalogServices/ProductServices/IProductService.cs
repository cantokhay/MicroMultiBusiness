using MicroMultiBusiness.DTOLayer.CatalogDTOs.ProductDTOs;

namespace MicroMultiBusiness.WebUI.Services.CatalogServices.ProductServices
{
    public interface IProductService
    {
        Task<List<ResultProductDTO>> GetAllProductsAsync();
        Task CreateProductAsync(CreateProductDTO createProductDTO);
        Task UpdateProductAsync(UpdateProductDTO updateProductDTO);
        Task DeleteProductAsync(string id);
        Task<UpdateProductDTO> GetByIdProductAsync(string id);
        Task<List<ResultProductWtihCategoryDTO>> GetAllProductsWithCategoryAsync();
        Task<List<ResultProductWtihCategoryDTO>> GetProductsWithCategoryByCategoryIdAsync(string categoryId);
    }
}
