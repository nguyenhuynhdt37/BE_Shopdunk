using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE_Shopdunk.Model;
using MongoDB.Driver;

namespace BE_Shopdunk.Data
{
    public class MongoDBContext
    {
        private readonly IMongoDatabase _database;
        public MongoDBContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetConnectionString("Default"));
            _database = client.GetDatabase(configuration["DataBaseName"]);
        }
        public IMongoCollection<User> Users => _database.GetCollection<User>("Users");
        public IMongoCollection<Role> Roles => _database.GetCollection<Role>("Roles");
        public IMongoCollection<Category> Categorys => _database.GetCollection<Category>("Categorys");
    }
}