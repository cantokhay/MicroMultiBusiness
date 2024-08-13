using AutoMapper;
using MicroMultiBusiness.Catalog.DTOs.ProductDetailDTOs;
using MicroMultiBusiness.Catalog.Entities;
using MicroMultiBusiness.Catalog.Settings;
using MongoDB.Driver;

namespace MicroMultiBusiness.Catalog.Services.ProductDetailServices
{
    public class ProductDetailService : IProductDetailService
    {
        private readonly IMongoCollection<ProductDetail> _productDetailCollection;
        private readonly IMapper _mapper;

        public ProductDetailService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString); //mongodb connection string implementation
            var database = client.GetDatabase(_databaseSettings.DatabaseName);  //mongodb built-in method to get database
            _productDetailCollection = database.GetCollection<ProductDetail>(_databaseSettings.ProductDetailCollectionName); //mongodb built-in method to get collection(table)
            _mapper = mapper;
        }

        public async Task CreateProductDetailAsync(CreateProductDetailDTO createProductDetailDTO)
        {
            var productDetail = _mapper.Map<ProductDetail>(createProductDetailDTO);
            await _productDetailCollection.InsertOneAsync(productDetail); //mongodb built-in method to insert document(row)
        }

        public async Task DeleteProductDetailAsync(string id)
        {
            await _productDetailCollection.DeleteOneAsync(x => x.ProductDetailId == id); //mongodb built-in method to delete document(row)
        }

        public async Task<List<ResultProductDetailDTO>> GetAllProductDetailsAsync()
        {
            var productDetails = await _productDetailCollection.Find(x => true).ToListAsync(); //mongodb built-in method to get all documents in list(rows)
            return _mapper.Map<List<ResultProductDetailDTO>>(productDetails);
        }

        public async Task<GetByIdProductDetailDTO> GetByIdProductDetailAsync(string id)
        {
            var productDetail = await _productDetailCollection.Find<ProductDetail>(x => x.ProductDetailId == id).FirstOrDefaultAsync(); //mongodb built-in method to get a document(row) by id
            return _mapper.Map<GetByIdProductDetailDTO>(productDetail);
        }

        public async Task<GetByIdProductDetailDTO> GetByProductIdProductDetailAsync(string id)
        {
            var productDetail = await _productDetailCollection.Find<ProductDetail>(x => x.ProductId == id).FirstOrDefaultAsync(); //mongodb built-in method to get a document(row) by id
            return _mapper.Map<GetByIdProductDetailDTO>(productDetail);
        }

        public async Task UpdateProductDetailAsync(UpdateProductDetailDTO updateProductDetailDTO)
        {
            var productDetailToUpdate = _mapper.Map<ProductDetail>(updateProductDetailDTO);
            await _productDetailCollection.FindOneAndReplaceAsync(x => x.ProductDetailId == updateProductDetailDTO.ProductDetailId, productDetailToUpdate); //mongodb built-in method to update a document(row)
        }
    }
}
