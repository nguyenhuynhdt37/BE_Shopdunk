using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE_Shopdunk.Data;
using BE_Shopdunk.Interface;
using BE_Shopdunk.Model;
using MongoDB.Bson;
using MongoDB.Driver;

namespace BE_Shopdunk.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<User> _users;

        public UserRepository(MongoDBContext context)
        {
            _users = context.Users;
        }

        public async Task<User> GetByIdAsync(ObjectId id)
        {
            return await _users.Find(user => user.Id == id).FirstOrDefaultAsync();
        }

        public async Task CreateAsync(User user)
        {
            await _users.InsertOneAsync(user);
        }

        public async Task UpdateAsync(User user)
        {
            await _users.ReplaceOneAsync(u => u.Id == user.Id, user);
        }

        public async Task DeleteAsync(ObjectId id)
        {
            await _users.DeleteOneAsync(user => user.Id == id);
        }
    }
}