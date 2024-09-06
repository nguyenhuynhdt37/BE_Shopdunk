using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;

namespace BE_Shopdunk.Model
{
    public class MemoryOption
    {
        [BsonElement("storage")]
        public string? Storage { get; set; }

        [BsonElement("price")]
        public decimal Price { get; set; }
    }
}