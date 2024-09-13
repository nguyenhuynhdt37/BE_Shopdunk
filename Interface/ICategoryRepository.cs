using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE_Shopdunk.Model;
using MongoDB.Bson;

namespace BE_Shopdunk.Interface
{
    public interface ICategoryRepository
    {
        public Task<bool> isCategoryAsync(string name);
        public Task CategoryCreateAsync(string name, ObjectId user_id);
        public Task<Category?> getCatgoryByID(ObjectId Id);
    }

}