using AutoMapper;
using MicroMultiBusiness.Catalog.DTOs.OfferDiscountDTOs;
using MicroMultiBusiness.Catalog.Entities;
using MicroMultiBusiness.Catalog.Settings;
using MongoDB.Driver;

namespace MicroMultiBusiness.Catalog.Services.OfferDiscountServices
{
    public class OfferDiscountService : IOfferDiscountService
    {
        private readonly IMongoCollection<OfferDiscount> _offerDiscountCollection;
        private readonly IMapper _mapper;

        public OfferDiscountService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString); //mongodb connection string implementation
            var database = client.GetDatabase(_databaseSettings.DatabaseName);  //mongodb built-in method to get database
            _offerDiscountCollection = database.GetCollection<OfferDiscount>(_databaseSettings.OfferDiscountCollectionName); //mongodb built-in method to get collection(table)
            _mapper = mapper;
        }

        public async Task CreateOfferDiscountAsync(CreateOfferDiscountDTO createOfferDiscountDTO)
        {
            var value = _mapper.Map<OfferDiscount>(createOfferDiscountDTO);
            await _offerDiscountCollection.InsertOneAsync(value); //mongodb built-in method to insert document(row)
        }

        public async Task DeleteOfferDiscountAsync(string id)
        {
            await _offerDiscountCollection.DeleteOneAsync(x => x.OfferDiscountId == id); //mongodb built-in method to delete document(row)
        }

        public async Task<List<ResultOfferDiscountDTO>> GetAllOfferDiscountsAsync()
        {
            var valuesList = await _offerDiscountCollection.Find(x => true).ToListAsync(); //mongodb built-in method to get all documents in list(rows)
            return _mapper.Map<List<ResultOfferDiscountDTO>>(valuesList);
        }

        public async Task<GetByIdOfferDiscountDTO> GetByIdOfferDiscountAsync(string id)
        {
            var value = await _offerDiscountCollection.Find<OfferDiscount>(x => x.OfferDiscountId == id).FirstOrDefaultAsync(); //mongodb built-in method to get a document(row) by id
            return _mapper.Map<GetByIdOfferDiscountDTO>(value);
        }

        public async Task UpdateOfferDiscountAsync(UpdateOfferDiscountDTO updateOfferDiscountDTO)
        {
            var valueToUpdate = _mapper.Map<OfferDiscount>(updateOfferDiscountDTO);
            await _offerDiscountCollection.FindOneAndReplaceAsync(x => x.OfferDiscountId == updateOfferDiscountDTO.OfferDiscountId, valueToUpdate);
        }
    }
}
