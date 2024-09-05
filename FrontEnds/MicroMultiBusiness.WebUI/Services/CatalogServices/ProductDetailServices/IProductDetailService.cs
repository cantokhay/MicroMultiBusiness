using MicroMultiBusiness.DTOLayer.CatalogDTOs.ProductDetailDTOs;

namespace MicroMultiBusiness.WebUI.Services.CatalogServices.ProductDetailServices
{
    public interface IProductDetailService
    {
        Task<List<ResultProductDetailDTO>> GetAllProductDetailsAsync();
        Task CreateProductDetailAsync(CreateProductDetailDTO createProductDetailDTO);
        Task UpdateProductDetailAsync(UpdateProductDetailDTO updateProductDetailDTO);
        Task DeleteProductDetailAsync(string id);
        Task<GetByIdProductDetailDTO> GetByIdProductDetailAsync(string id);
        Task<GetByIdProductDetailDTO> GetByProductIdProductDetailAsync(string id);
    }
}
