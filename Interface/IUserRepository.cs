using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE_Shopdunk.Dtos.User;
using BE_Shopdunk.Model;
using MongoDB.Bson;

namespace BE_Shopdunk.Interface
{
    public interface IUserRepository
    {
        public Task DeleteAsync(ObjectId id);
        public Task UpdateAsync(User user);
        public Task<User> CreateAsync(User user);
        public Task<User> GetByIdAsync(ObjectId id);
        public Task<bool> checkUser(string name);
        public Task<List<User>> getAllUsersAsync();
        public Task<User?> CheckLoginAsync(UserLoginDto user);
    }
}