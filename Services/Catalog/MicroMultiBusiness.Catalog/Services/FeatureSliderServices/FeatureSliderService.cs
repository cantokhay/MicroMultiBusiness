using AutoMapper;
using MicroMultiBusiness.Catalog.DTOs.CategoryDTOs;
using MicroMultiBusiness.Catalog.DTOs.FeatureSliderDTOs;
using MicroMultiBusiness.Catalog.Entities;
using MicroMultiBusiness.Catalog.Settings;
using MongoDB.Driver;

namespace MicroMultiBusiness.Catalog.Services.FeatureSliderServices
{
    public class FeatureSliderService : IFeatureSliderService
    {
        private readonly IMongoCollection<FeatureSlider> _featureSliderCollection;
        private readonly IMapper _mapper;

        public FeatureSliderService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString); //mongodb connection string implementation
            var database = client.GetDatabase(_databaseSettings.DatabaseName);  //mongodb built-in method to get database
            _featureSliderCollection = database.GetCollection<FeatureSlider>(_databaseSettings.FeatureSliderCollectionName); //mongodb built-in method to get collection(table)
            _mapper = mapper;
        }
        public async Task CreateFeatureSliderAsync(CreateFeatureSliderDTO createFeatureSliderDTO)
        {
            var value = _mapper.Map<FeatureSlider>(createFeatureSliderDTO);
            await _featureSliderCollection.InsertOneAsync(value); //mongodb built-in method to insert document(row)
        }

        public async Task DeleteFeatureSliderAsync(string id)
        {
            await _featureSliderCollection.DeleteOneAsync(x => x.FeatureSliderId == id); //mongodb built-in method to delete document(row)
        }

        public Task FeatureSliderStatusFalse(string id)
        {
            throw new NotImplementedException();
        }

        public Task FeatureSliderStatusTrue(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ResultFeatureSliderDTO>> GetAllFeatureSlidersAsync()
        {
            var valuesList = await _featureSliderCollection.Find(x => true).ToListAsync(); //mongodb built-in method to get all documents in list(rows)
            return _mapper.Map<List<ResultFeatureSliderDTO>>(valuesList);
        }

        public async Task<GetByIdFeatureSliderDTO> GetByIdFeatureSliderAsync(string id)
        {
            var value = await _featureSliderCollection.Find<FeatureSlider>(x => x.FeatureSliderId == id).FirstOrDefaultAsync(); //mongodb built-in method to get a document(row) by id
            return _mapper.Map<GetByIdFeatureSliderDTO>(value);
        }

        public async Task UpdateFeatureSliderAsync(UpdateFeatureSliderDTO updateFeatureSliderDTO)
        {
            var valueToUpdate = _mapper.Map<FeatureSlider>(updateFeatureSliderDTO);
            await _featureSliderCollection.FindOneAndReplaceAsync(x => x.FeatureSliderId == updateFeatureSliderDTO.FeatureSliderId, valueToUpdate); //mongodb built-in method to update a document(row)
        }
    }
}
