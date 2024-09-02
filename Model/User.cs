using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BE_Shopdunk.Model
{
    public class User
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonRequired]
        public string? UserName { get; set; }
        [BsonRequired]
        public string? Email { get; set; }
        [BsonRequired]
        public string? PasswordHash { get; set; }

        public string? Avatar { get; set; }
        [BsonRequired]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        [BsonIgnoreIfNull]
        public DateTime LastAccessTime { get; set; }
        public ObjectId RoleID { get; set; }
        [BsonIgnoreIfNull]
        public Role? Role { get; set; }
    }
}