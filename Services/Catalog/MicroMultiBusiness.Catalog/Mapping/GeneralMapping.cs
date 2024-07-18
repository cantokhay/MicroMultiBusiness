using AutoMapper;
using MicroMultiBusiness.Catalog.DTOs.CategoryDTOs;
using MicroMultiBusiness.Catalog.DTOs.ProductDetailDTOs;
using MicroMultiBusiness.Catalog.DTOs.ProductDTOs;
using MicroMultiBusiness.Catalog.DTOs.ProductImageDTOs;
using MicroMultiBusiness.Catalog.Entities;

namespace MicroMultiBusiness.Catalog.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Category, ResultCategoryDTO>().ReverseMap();
            CreateMap<Category, CreateCategoryDTO>().ReverseMap();
            CreateMap<Category, UpdateCategoryDTO>().ReverseMap();
            CreateMap<Category, GetByIdCategoryDTO>().ReverseMap();

            CreateMap<Product, ResultProductDTO>().ReverseMap();
            CreateMap<Product, CreateProductDTO>().ReverseMap();
            CreateMap<Product, UpdateProductDTO>().ReverseMap();
            CreateMap<Product, GetByIdProductDTO>().ReverseMap();

            CreateMap<ProductDetail, ResultProductDetailDTO>().ReverseMap();
            CreateMap<ProductDetail, CreateProductDetailDTO>().ReverseMap();
            CreateMap<ProductDetail, UpdateProductDetailDTO>().ReverseMap();
            CreateMap<ProductDetail, GetByIdProductDetailDTO>().ReverseMap();

            CreateMap<ProductImage, ResultProductImageDTO>().ReverseMap();
            CreateMap<ProductImage, CreateProductImageDTO>().ReverseMap();
            CreateMap<ProductImage, UpdateProductImageDTO>().ReverseMap();
            CreateMap<ProductImage, GetByIdProductImageDTO>().ReverseMap();
        }
    }
}
