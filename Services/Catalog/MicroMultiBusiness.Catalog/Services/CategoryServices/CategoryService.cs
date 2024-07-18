using AutoMapper;
using MicroMultiBusiness.Catalog.DTOs.CategoryDTOs;
using MicroMultiBusiness.Catalog.Entities;
using MicroMultiBusiness.Catalog.Settings;
using MongoDB.Driver;

namespace MicroMultiBusiness.Catalog.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;

        public CategoryService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString); //mongodb connection string implementation
            var database = client.GetDatabase(_databaseSettings.DatabaseName);  //mongodb built-in method to get database
            _categoryCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName); //mongodb built-in method to get collection(table)
            _mapper = mapper;
        }

        public async Task CreateCategoryAsync(CreateCategoryDTO createCategoryDTO)
        {
            var category = _mapper.Map<Category>(createCategoryDTO);
            await _categoryCollection.InsertOneAsync(category); //mongodb built-in method to insert document(row)
        }

        public async Task DeleteCategoryAsync(string id)
        {
            await _categoryCollection.DeleteOneAsync(x => x.CategoryId == id); //mongodb built-in method to delete document(row)
        }

        public async Task<List<ResultCategoryDTO>> GetAllCategoriesAsync()
        {
            var categories = await _categoryCollection.Find(x => true).ToListAsync(); //mongodb built-in method to get all documents in list(rows)
            return _mapper.Map<List<ResultCategoryDTO>>(categories);
        }

        public async Task<GetByIdCategoryDTO> GetByIdCategoryAsync(string id)
        {
            var category = await _categoryCollection.Find<Category>(x => x.CategoryId == id).FirstOrDefaultAsync(); //mongodb built-in method to get a document(row) by id
            return _mapper.Map<GetByIdCategoryDTO>(category);
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDTO updateCategoryDTO)
        {
            var categoryToUpdate = _mapper.Map<Category>(updateCategoryDTO);
            await _categoryCollection.FindOneAndReplaceAsync(x => x.CategoryId == updateCategoryDTO.CategoryId, categoryToUpdate); //mongodb built-in method to update a document(row)
        }
    }
}
