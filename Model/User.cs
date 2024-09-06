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
        [BsonElement("id")]
        public ObjectId Id { get; set; }
        [BsonRequired]
        [BsonElement("user_name")]
        public string? UserName { get; set; }
        [BsonRequired]
        [BsonElement("email")]
        public string? Email { get; set; }
        [BsonRequired]
        [BsonElement("password")]
        public string? PasswordHash { get; set; }

        [BsonElement("avatar")]
        public string? Avatar { get; set; }
        [BsonRequired]
        [BsonElement("cretead_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        [BsonIgnoreIfNull]
        [BsonElement("last_access")]
        public DateTime LastAccessTime { get; set; }
        [BsonElement("role_id")]
        public ObjectId RoleID { get; set; }
        [BsonIgnoreIfNull]
        public Role? Role { get; set; }

    }
}