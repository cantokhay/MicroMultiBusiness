using AutoMapper;
using MicroMultiBusiness.Catalog.DTOs.AboutDTOs;
using MicroMultiBusiness.Catalog.Entities;
using MicroMultiBusiness.Catalog.Settings;
using MongoDB.Driver;

namespace MicroMultiBusiness.Catalog.Services.AboutServices
{
    public class AboutService : IAboutService
    {
        private readonly IMongoCollection<About> _aboutCollection;
        private readonly IMapper _mapper;

        public AboutService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString); //mongodb connection string implementation
            var database = client.GetDatabase(_databaseSettings.DatabaseName);  //mongodb built-in method to get database
            _aboutCollection = database.GetCollection<About>(_databaseSettings.AboutCollectionName); //mongodb built-in method to get collection(table)
            _mapper = mapper;
        }

        public async Task CreateAboutAsync(CreateAboutDTO createAboutDTO)
        {
            var value = _mapper.Map<About>(createAboutDTO);
            await _aboutCollection.InsertOneAsync(value); //mongodb built-in method to insert document(row)
        }

        public async Task DeleteAboutAsync(string id)
        {
            await _aboutCollection.DeleteOneAsync(x => x.AboutId == id); //mongodb built-in method to delete document(row)
        }

        public async Task<List<ResultAboutDTO>> GetAllAboutsAsync()
        {
            var valuesList = await _aboutCollection.Find(x => true).ToListAsync(); //mongodb built-in method to get all documents in list(rows)
            return _mapper.Map<List<ResultAboutDTO>>(valuesList);
        }

        public async Task<GetByIdAboutDTO> GetByIdAboutAsync(string id)
        {
            var value = await _aboutCollection.Find<About>(x => x.AboutId == id).FirstOrDefaultAsync(); //mongodb built-in method to get a document(row) by id
            return _mapper.Map<GetByIdAboutDTO>(value);
        }

        public async Task UpdateAboutAsync(UpdateAboutDTO updateAboutDTO)
        {
            var valueToUpdate = _mapper.Map<About>(updateAboutDTO);
            await _aboutCollection.FindOneAndReplaceAsync(x => x.AboutId == updateAboutDTO.AboutId, valueToUpdate);
        }
    }
}
