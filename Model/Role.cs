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
        public ObjectId Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; } = null;
    }
}