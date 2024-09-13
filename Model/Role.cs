using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BE_Shopdunk.Model
{
    public class Role
    {
        [BsonId]
        [BsonElement("id")]

        public ObjectId Id { get; set; }

        [BsonRequired]
        [BsonElement("name")]
        public string? Name { get; set; }
        
        [BsonIgnoreIfNull]
        [BsonElement("description")]

        public string? Description { get; set; } = null;
    }
}