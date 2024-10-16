using MicroMultiBusiness.Catalog.Entities;
using MicroMultiBusiness.Catalog.Settings;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MicroMultiBusiness.Catalog.Services.StatisticServices
{
    public class StatisticService : IStatisticService
    {
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMongoCollection<Brand> _brandCollection;

        public StatisticService(IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
            _categoryCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
            _brandCollection = database.GetCollection<Brand>(_databaseSettings.BrandCollectionName);
        }

        public async Task<decimal> GetAvgProductPrice() //todo : this method is not working properly, it should be fixed
        {
            var pipeline = new BsonDocument[]
            {
                new BsonDocument("$group", new BsonDocument
                {
                    { "_id", "null" },
                    { "average", new BsonDocument("$avg", "$ProductPrice") }
                })
            };

            var result = await _productCollection.AggregateAsync<BsonDocument>(pipeline);
            var avgPrice = result.FirstOrDefault().GetValue("average", decimal.Zero).ToDecimal();

            return avgPrice;
        }

        public async Task<long> GetBrandCount()
        {
            return await _brandCollection.CountDocumentsAsync(FilterDefinition<Brand>.Empty); //this built-in method returns long, filter definiton is empty means search all without any filter
        }

        public async Task<long> GetCategoryCount()
        {
            return await _categoryCollection.CountDocumentsAsync(FilterDefinition<Category>.Empty);
        }

        public async Task<string> GetMaxPriceProductName()
        {
            var filter = Builders<Product>.Filter.Empty;
            var sort = Builders<Product>.Sort.Descending(x => x.ProductPrice);
            var projection = Builders<Product>.Projection.Include(y => y.ProductName)
                                                                                 .Exclude(z => z.ProductId);
            var result = await _productCollection.Find(filter).Sort(sort).Project(projection).FirstOrDefaultAsync();
            return result.GetValue("ProductName").AsString;
        }

        public async Task<string> GetMinPriceProductName()
        {
            var filter = Builders<Product>.Filter.Empty;
            var sort = Builders<Product>.Sort.Ascending(x => x.ProductPrice);
            var projection = Builders<Product>.Projection.Include(y => y.ProductName)
                                                                                 .Exclude(z => z.ProductId);
            var result = await _productCollection.Find(filter).Sort(sort).Project(projection).FirstOrDefaultAsync();
            return result.GetValue("ProductName").AsString;
        }

        public async Task<long> GetProductCount()
        {
            return await _productCollection.CountDocumentsAsync(FilterDefinition<Product>.Empty);
        }
    }
}
