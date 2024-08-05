using AutoMapper;
using MicroMultiBusiness.Catalog.DTOs.FeatureDTOs;
using MicroMultiBusiness.Catalog.Entities;
using MicroMultiBusiness.Catalog.Settings;
using MongoDB.Driver;

namespace MicroMultiBusiness.Catalog.Services.FeatureServices
{
    public class FeatureService : IFeatureService
    {
        private readonly IMongoCollection<Feature> _featureCollection;
        private readonly IMapper _mapper;

        public FeatureService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString); //mongodb connection string implementation
            var database = client.GetDatabase(_databaseSettings.DatabaseName);  //mongodb built-in method to get database
            _featureCollection = database.GetCollection<Feature>(_databaseSettings.FeatureCollectionName); //mongodb built-in method to get collection(table)
            _mapper = mapper;
        }

        public async Task CreateFeatureAsync(CreateFeatureDTO createFeatureDTO)
        {
            var value = _mapper.Map<Feature>(createFeatureDTO);
            await _featureCollection.InsertOneAsync(value); //mongodb built-in method to insert document(row)
        }

        public async Task DeleteFeatureAsync(string id)
        {
            await _featureCollection.DeleteOneAsync(x => x.FeatureId == id); //mongodb built-in method to delete document(row)
        }

        public async Task<List<ResultFeatureDTO>> GetAllFeaturesAsync()
        {
            var valuesList = await _featureCollection.Find(x => true).ToListAsync(); //mongodb built-in method to get all documents in list(rows)
            return _mapper.Map<List<ResultFeatureDTO>>(valuesList);
        }

        public async Task<GetByIdFeatureDTO> GetByIdFeatureAsync(string id)
        {
            var value = await _featureCollection.Find<Feature>(x => x.FeatureId == id).FirstOrDefaultAsync(); //mongodb built-in method to get a document(row) by id
            return _mapper.Map<GetByIdFeatureDTO>(value);
        }

        public async Task UpdateFeatureAsync(UpdateFeatureDTO updateFeatureDTO)
        {
            var valueToUpdate = _mapper.Map<Feature>(updateFeatureDTO);
            await _featureCollection.FindOneAndReplaceAsync(x => x.FeatureId == updateFeatureDTO.FeatureId, valueToUpdate);
        }
    }
}
