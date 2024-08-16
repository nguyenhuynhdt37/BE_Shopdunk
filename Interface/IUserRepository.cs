using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE_Shopdunk.Model;
using MongoDB.Bson;

namespace BE_Shopdunk.Interface
{
    public interface IUserRepository
    {
        public Task DeleteAsync(ObjectId id);
        public Task UpdateAsync(User user);
        public Task CreateAsync(User user);
        public Task<User> GetByIdAsync(ObjectId id);
    }
}