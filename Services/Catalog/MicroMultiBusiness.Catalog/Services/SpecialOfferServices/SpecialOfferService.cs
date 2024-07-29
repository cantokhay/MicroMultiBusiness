using AutoMapper;
using MicroMultiBusiness.Catalog.DTOs.FeatureSliderDTOs;
using MicroMultiBusiness.Catalog.DTOs.SpecialOfferDTOs;
using MicroMultiBusiness.Catalog.Entities;
using MicroMultiBusiness.Catalog.Settings;
using MongoDB.Driver;

namespace MicroMultiBusiness.Catalog.Services.SpecialOfferServices
{
    public class SpecialOfferService : ISpecialOfferService
    {
        private readonly IMongoCollection<SpecialOffer> _specialOfferCollection;
        private readonly IMapper _mapper;

        public SpecialOfferService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString); //mongodb connection string implementation
            var database = client.GetDatabase(_databaseSettings.DatabaseName);  //mongodb built-in method to get database
            _specialOfferCollection = database.GetCollection<SpecialOffer>(_databaseSettings.SpecialOfferCollectionName); //mongodb built-in method to get collection(table)
            _mapper = mapper;
        }

        public async Task CreateSpecialOfferAsync(CreateSpecialOfferDTO createSpecialOfferDTO)
        {
            var value = _mapper.Map<SpecialOffer>(createSpecialOfferDTO);
            await _specialOfferCollection.InsertOneAsync(value); //mongodb built-in method to insert document(row)
        }

        public async Task DeleteSpecialOfferAsync(string id)
        {
            await _specialOfferCollection.DeleteOneAsync(x => x.SpecialOfferId == id); //mongodb built-in method to delete document(row)
        }

        public async Task<List<ResultSpecialOfferDTO>> GetAllSpecialOffersAsync()
        {
            var valuesList = await _specialOfferCollection.Find(x => true).ToListAsync(); //mongodb built-in method to get all documents in list(rows)
            return _mapper.Map<List<ResultSpecialOfferDTO>>(valuesList);
        }

        public async Task<GetByIdSpecialOfferDTO> GetByIdSpecialOfferAsync(string id)
        {
            var value = await _specialOfferCollection.Find<SpecialOffer>(x => x.SpecialOfferId == id).FirstOrDefaultAsync(); //mongodb built-in method to get a document(row) by id
            return _mapper.Map<GetByIdSpecialOfferDTO>(value);
        }

        public async Task UpdateSpecialOfferAsync(UpdateSpecialOfferDTO updateSpecialOfferDTO)
        {
            var valueToUpdate = _mapper.Map<SpecialOffer>(updateSpecialOfferDTO);
            await _specialOfferCollection.FindOneAndReplaceAsync(x => x.SpecialOfferId == updateSpecialOfferDTO.SpecialOfferId, valueToUpdate);
        }
    }
}
