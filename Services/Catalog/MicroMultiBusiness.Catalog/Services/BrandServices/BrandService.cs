using AutoMapper;
using MicroMultiBusiness.Catalog.DTOs.BrandDTOs;
using MicroMultiBusiness.Catalog.Entities;
using MicroMultiBusiness.Catalog.Settings;
using MongoDB.Driver;

namespace MicroMultiBusiness.Catalog.Services.BrandServices
{
    public class BrandService : IBrandService
    {
        private readonly IMongoCollection<Brand> _brandCollection;
        private readonly IMapper _mapper;

        public BrandService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString); //mongodb connection string implementation
            var database = client.GetDatabase(_databaseSettings.DatabaseName);  //mongodb built-in method to get database
            _brandCollection = database.GetCollection<Brand>(_databaseSettings.BrandCollectionName); //mongodb built-in method to get collection(table)
            _mapper = mapper;
        }

        public async Task CreateBrandAsync(CreateBrandDTO createBrandDTO)
        {
            var value = _mapper.Map<Brand>(createBrandDTO);
            await _brandCollection.InsertOneAsync(value); //mongodb built-in method to insert document(row)
        }

        public async Task DeleteBrandAsync(string id)
        {
            await _brandCollection.DeleteOneAsync(x => x.BrandId == id); //mongodb built-in method to delete document(row)
        }

        public async Task<List<ResultBrandDTO>> GetAllBrandsAsync()
        {
            var valuesList = await _brandCollection.Find(x => true).ToListAsync(); //mongodb built-in method to get all documents in list(rows)
            return _mapper.Map<List<ResultBrandDTO>>(valuesList);
        }

        public async Task<GetByIdBrandDTO> GetByIdBrandAsync(string id)
        {
            var value = await _brandCollection.Find<Brand>(x => x.BrandId == id).FirstOrDefaultAsync(); //mongodb built-in method to get a document(row) by id
            return _mapper.Map<GetByIdBrandDTO>(value);
        }

        public async Task UpdateBrandAsync(UpdateBrandDTO updateBrandDTO)
        {
            var valueToUpdate = _mapper.Map<Brand>(updateBrandDTO);
            await _brandCollection.FindOneAndReplaceAsync(x => x.BrandId == updateBrandDTO.BrandId, valueToUpdate);
        }
    }
}
