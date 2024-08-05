using AutoMapper;
using MicroMultiBusiness.Catalog.DTOs.AboutDTOs;
using MicroMultiBusiness.Catalog.DTOs.BrandDTOs;
using MicroMultiBusiness.Catalog.DTOs.CategoryDTOs;
using MicroMultiBusiness.Catalog.DTOs.FeatureDTOs;
using MicroMultiBusiness.Catalog.DTOs.FeatureSliderDTOs;
using MicroMultiBusiness.Catalog.DTOs.OfferDiscountDTOs;
using MicroMultiBusiness.Catalog.DTOs.ProductDetailDTOs;
using MicroMultiBusiness.Catalog.DTOs.ProductDTOs;
using MicroMultiBusiness.Catalog.DTOs.ProductImageDTOs;
using MicroMultiBusiness.Catalog.DTOs.SpecialOfferDTOs;
using MicroMultiBusiness.Catalog.Entities;

namespace MicroMultiBusiness.Catalog.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<About, ResultAboutDTO>().ReverseMap();
            CreateMap<About, CreateAboutDTO>().ReverseMap();
            CreateMap<About, UpdateAboutDTO>().ReverseMap();
            CreateMap<About, GetByIdAboutDTO>().ReverseMap();

            CreateMap<Brand, ResultBrandDTO>().ReverseMap();
            CreateMap<Brand, CreateBrandDTO>().ReverseMap();
            CreateMap<Brand, UpdateBrandDTO>().ReverseMap();
            CreateMap<Brand, GetByIdBrandDTO>().ReverseMap();

            CreateMap<Category, ResultCategoryDTO>().ReverseMap();
            CreateMap<Category, CreateCategoryDTO>().ReverseMap();
            CreateMap<Category, UpdateCategoryDTO>().ReverseMap();
            CreateMap<Category, GetByIdCategoryDTO>().ReverseMap();

            CreateMap<Product, ResultProductDTO>().ReverseMap();
            CreateMap<Product, CreateProductDTO>().ReverseMap();
            CreateMap<Product, UpdateProductDTO>().ReverseMap();
            CreateMap<Product, GetByIdProductDTO>().ReverseMap();
            CreateMap<Product, ResultProductWithCategoryDTO>().ReverseMap();

            CreateMap<ProductDetail, ResultProductDetailDTO>().ReverseMap();
            CreateMap<ProductDetail, CreateProductDetailDTO>().ReverseMap();
            CreateMap<ProductDetail, UpdateProductDetailDTO>().ReverseMap();
            CreateMap<ProductDetail, GetByIdProductDetailDTO>().ReverseMap();

            CreateMap<ProductImage, ResultProductImageDTO>().ReverseMap();
            CreateMap<ProductImage, CreateProductImageDTO>().ReverseMap();
            CreateMap<ProductImage, UpdateProductImageDTO>().ReverseMap();
            CreateMap<ProductImage, GetByIdProductImageDTO>().ReverseMap();

            CreateMap<FeatureSlider, ResultFeatureSliderDTO>().ReverseMap();
            CreateMap<FeatureSlider, CreateFeatureSliderDTO>().ReverseMap();
            CreateMap<FeatureSlider, UpdateFeatureSliderDTO>().ReverseMap();
            CreateMap<FeatureSlider, GetByIdFeatureSliderDTO>().ReverseMap();

            CreateMap<SpecialOffer, ResultSpecialOfferDTO>().ReverseMap();
            CreateMap<SpecialOffer, CreateSpecialOfferDTO>().ReverseMap();
            CreateMap<SpecialOffer, UpdateSpecialOfferDTO>().ReverseMap();
            CreateMap<SpecialOffer, GetByIdSpecialOfferDTO>().ReverseMap();

            CreateMap<Feature, ResultFeatureDTO>().ReverseMap();
            CreateMap<Feature, CreateFeatureDTO>().ReverseMap();
            CreateMap<Feature, UpdateFeatureDTO>().ReverseMap();
            CreateMap<Feature, GetByIdFeatureDTO>().ReverseMap();

            CreateMap<OfferDiscount, ResultOfferDiscountDTO>().ReverseMap();
            CreateMap<OfferDiscount, CreateOfferDiscountDTO>().ReverseMap();
            CreateMap<OfferDiscount, UpdateOfferDiscountDTO>().ReverseMap();
            CreateMap<OfferDiscount, GetByIdOfferDiscountDTO>().ReverseMap();
        }
    }
}
