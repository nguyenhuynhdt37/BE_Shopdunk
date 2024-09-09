
using BE_Shopdunk.Data;
using BE_Shopdunk.Dtos.User;
using BE_Shopdunk.Interface;
using BE_Shopdunk.Model;
using MongoDB.Bson;
using MongoDB.Driver;

namespace BE_Shopdunk.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<User> _users;
        private readonly IMongoCollection<Role> _roles;

        public UserRepository(MongoDBContext context)
        {
            _users = context.Users;
            _roles = context.Roles;
        }

        public async Task<User> GetByIdAsync(ObjectId id)
        {
            var result = await _users.Aggregate()
            .Match(x => x.Id == id)
              .Lookup<User, Role, User>(
                _roles,
                user => user.RoleID,
                role => role.Id,
                user => user.Role
              )
              .Unwind(u => u.Role)
              .As<User>()
              .FirstOrDefaultAsync();
            return result;
        }

        public async Task<User> CreateAsync(User user)
        {

            var role = await _roles.Find(x => x.Name == "Client").FirstOrDefaultAsync();
            if (role == null)
            {
                role = new Role
                {
                    Name = "Client",
                    Description = "Client role"
                };
                await _roles.InsertOneAsync(role);
                return await CreateAsync(user);
            }
            user.RoleID = role.Id;
            user.UserName = user.UserName?.ToLowerInvariant();
            user.PasswordHash = PasswordHelper.HashPassword(user?.PasswordHash);
            await _users.InsertOneAsync(user);
            return await _users.Find(x => x.UserName == user.UserName).FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(User user)
        {
            await _users.ReplaceOneAsync(u => u.Id == user.Id, user);
        }

        public async Task DeleteAsync(ObjectId id)
        {
            await _users.DeleteOneAsync(user => user.Id == id);
        }
        public async Task<bool> checkUser(string userName)
        {
            var userModel = await _users.Find(x => x.UserName == userName).FirstOrDefaultAsync();
            return userModel == null ? false : true;
        }

        public async Task<List<User>> getAllUsersAsync()
        {
            var result = await _users.Aggregate()
              .Lookup<User, Role, User>(
                _roles,
                user => user.RoleID,
                role => role.Id,
                user => user.Role
              )
              .Unwind(u => u.Role)
              .As<User>()
              .ToListAsync();
            return result;
        }

        public async Task<User?> CheckLoginAsync(UserLoginDto user)
        {
            if (user == null || string.IsNullOrEmpty(user.UserName) || string.IsNullOrEmpty(user.PasswordHash))
            {
                return null;
            }

            var normalizedUserName = user.UserName.ToLower();
            var userModel = await _users.Find(x => x.UserName == normalizedUserName).FirstOrDefaultAsync();
            if (userModel == null) return null;
            else
            {
                if (!PasswordHelper.VerifyPassword(user.PasswordHash, userModel.PasswordHash))
                {
                    return null;
                }
            }
            var role = await _roles.Find(x => x.Id == userModel.RoleID).FirstOrDefaultAsync();
            userModel.Role = role;

            return userModel;
        }

    }
}