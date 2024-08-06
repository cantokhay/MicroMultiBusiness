using AutoMapper;
using MicroMultiBusiness.Catalog.DTOs.ProductImageDTOs;
using MicroMultiBusiness.Catalog.Entities;
using MicroMultiBusiness.Catalog.Settings;
using MongoDB.Driver;

namespace MicroMultiBusiness.Catalog.Services.ProductImageServices
{
    public class ProductImageService : IProductImageService
    {
        private readonly IMongoCollection<ProductImage> _productImageCollection;
        private readonly IMapper _mapper;

        public ProductImageService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productImageCollection = database.GetCollection<ProductImage>(_databaseSettings.ProductImageCollectionName);
            _mapper = mapper;
        }

        public async Task CreateProductImageAsync(CreateProductImageDTO createProductImageDTO)
        {
            var productImage = _mapper.Map<ProductImage>(createProductImageDTO);
            await _productImageCollection.InsertOneAsync(productImage);
        }

        public async Task DeleteProductImageAsync(string id)
        {
            await _productImageCollection.DeleteOneAsync(x => x.ProductImageId == id);
        }

        public async Task<List<ResultProductImageDTO>> GetAllProductImagesAsync()
        {
            var productImages = await _productImageCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductImageDTO>>(productImages);
        }

        public async Task<GetByIdProductImageDTO> GetAllProductImagesByProductIdAsync(string id)
        {
            var productImages = await _productImageCollection.Find(x => x.ProductId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductImageDTO>(productImages);
        }

        public async Task<GetByIdProductImageDTO> GetByIdProductImageAsync(string id)
        {
            var productImage = await _productImageCollection.Find<ProductImage>(x => x.ProductImageId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductImageDTO>(productImage);
        }

        public async Task UpdateProductImageAsync(UpdateProductImageDTO updateProductImageDTO)
        {
            var productImageToUpdate = _mapper.Map<ProductImage>(updateProductImageDTO);
            await _productImageCollection.FindOneAndReplaceAsync(x => x.ProductImageId == updateProductImageDTO.ProductImageId, productImageToUpdate);
        }
    }
}
