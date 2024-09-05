using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BE_Shopdunk.Interface;
using BE_Shopdunk.Model;
using MongoDB.Driver;


namespace BE_Shopdunk.Repositories
{
    public class CategoryRespostory : ICategoryRespostory
    {
        private readonly IMongoCollection<Category> _category;
        public CategoryRespostory(IMongoCollection<Category> category)
        {
            _category = category;
        }
        public async Task<string?> CategoryCreateAsync(string name)
        {
            var category = _category.Find(x => x.Name == name.ToLower()).FirstOrDefaultAsync();
            if (category != null) return "Category already exists";
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var categoryModel = new Category()
            {
                Name = name
            };
            await _category.InsertOne(categoryModel);
        }
    }
}