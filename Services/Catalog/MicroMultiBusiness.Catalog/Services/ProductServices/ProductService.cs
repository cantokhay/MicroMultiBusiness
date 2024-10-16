using AutoMapper;
using MicroMultiBusiness.Catalog.DTOs.ProductDTOs;
using MicroMultiBusiness.Catalog.Entities;
using MicroMultiBusiness.Catalog.Settings;
using MongoDB.Driver;

namespace MicroMultiBusiness.Catalog.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMongoCollection<Category> _categoryCollection;

        public ProductService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
            _categoryCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
            _mapper = mapper;
        }

        public async Task CreateProductAsync(CreateProductDTO createProductDTO)
        {
            var product = _mapper.Map<Product>(createProductDTO);
            await _productCollection.InsertOneAsync(product);
        }

        public async Task DeleteProductAsync(string id)
        {
            await _productCollection.DeleteOneAsync(x => x.ProductId == id);
        }

        public async Task<List<ResultProductDTO>> GetAllProductsAsync()
        {
            var products = await _productCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductDTO>>(products);
        }

        public async Task<List<ResultProductWithCategoryDTO>> GetAllProductsWithCategoryAsync()
        {
            var values = _productCollection.Find(x => true).ToList();
            foreach (var item in values)
            {
                item.Category = await _categoryCollection.Find<Category>(category => category.CategoryId == item.CategoryId).FirstAsync();
            }
            return _mapper.Map<List<ResultProductWithCategoryDTO>>(values);
        }

        public async Task<GetByIdProductDTO> GetByIdProductAsync(string id)
        {
            var product = await _productCollection.Find<Product>(x => x.ProductId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductDTO>(product);
        }

        public async Task<List<ResultProductWithCategoryDTO>> GetProductsWithCategoryByCategoryIdAsync(string categoryId)
        {
            var values = await _productCollection.Find(x => x.CategoryId == categoryId).ToListAsync();
            foreach (var item in values)
            {
                item.Category = await _categoryCollection.Find<Category>(category => category.CategoryId == item.CategoryId).FirstAsync();
            }
            return _mapper.Map<List<ResultProductWithCategoryDTO>>(values);
        }

        public Task UpdateProductAsync(UpdateProductDTO updateProductDTO)
        {
            var productToUpdate = _mapper.Map<Product>(updateProductDTO);
            return _productCollection.FindOneAndReplaceAsync(x => x.ProductId == updateProductDTO.ProductId, productToUpdate);
        }
    }
}
