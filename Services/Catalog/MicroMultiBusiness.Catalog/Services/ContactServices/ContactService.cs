using AutoMapper;
using MicroMultiBusiness.Catalog.DTOs.ContactDTOs;
using MicroMultiBusiness.Catalog.Entities;
using MicroMultiBusiness.Catalog.Settings;
using MongoDB.Driver;

namespace MicroMultiBusiness.Catalog.Services.ContactServices
{
    public class ContactService : IContactService
    {
        private readonly IMongoCollection<Contact> _contactCollection;
        private readonly IMapper _mapper;

        public ContactService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString); //mongodb connection string implementation
            var database = client.GetDatabase(_databaseSettings.DatabaseName);  //mongodb built-in method to get database
            _contactCollection = database.GetCollection<Contact>(_databaseSettings.ContactCollectionName); //mongodb built-in method to get collection(table)
            _mapper = mapper;
        }

        public async Task CreateContactAsync(CreateContactDTO createContactDTO)
        {
            var value = _mapper.Map<Contact>(createContactDTO);
            await _contactCollection.InsertOneAsync(value); //mongodb built-in method to insert document(row)
        }

        public async Task DeleteContactAsync(string id)
        {
            await _contactCollection.DeleteOneAsync(x => x.ContactId == id); //mongodb built-in method to delete document(row)
        }

        public async Task<List<ResultContactDTO>> GetAllContactsAsync()
        {
            var valuesList = await _contactCollection.Find(x => true).ToListAsync(); //mongodb built-in method to get all documents in list(rows)
            return _mapper.Map<List<ResultContactDTO>>(valuesList);
        }

        public async Task<GetByIdContactDTO> GetByIdContactAsync(string id)
        {
            var value = await _contactCollection.Find<Contact>(x => x.ContactId == id).FirstOrDefaultAsync(); //mongodb built-in method to get a document(row) by id
            return _mapper.Map<GetByIdContactDTO>(value);
        }

        public async Task UpdateContactAsync(UpdateContactDTO updateContactDTO)
        {
            var valueToUpdate = _mapper.Map<Contact>(updateContactDTO);
            await _contactCollection.FindOneAndReplaceAsync(x => x.ContactId == updateContactDTO.ContactId, valueToUpdate);
        }
    }
}
