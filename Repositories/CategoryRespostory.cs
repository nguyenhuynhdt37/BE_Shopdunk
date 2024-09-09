using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BE_Shopdunk.Data;
using BE_Shopdunk.Interface;
using BE_Shopdunk.Model;
using MongoDB.Bson;
using MongoDB.Driver;



namespace BE_Shopdunk.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IMongoCollection<Category> _category;
        public CategoryRepository(MongoDBContext context)
        {
            _category = context.Categorys;
        }
        public async Task<bool> isCategoryAsync(string name)
        {
            var category = await _category.Find(x => x.Name.ToLower() == name.ToLower()).FirstOrDefaultAsync();
            return category != null;
        }
        public async Task CategoryCreateAsync(string name, string User_id)
        {
            try
            {
                var categoryModel = new Category()
                {
                    Name = name,
                    SupplierId = new ObjectId(User_id)
                };
                await _category.InsertOneAsync(categoryModel);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating category: {ex.Message}");
                throw;
            }
        }
        public async Task<Category> CategoryGetByID(ObjectId id)
        {
            try
            {
                var data = await _category.Find(c => c.Id == id).FirstOrDefaultAsync();
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}