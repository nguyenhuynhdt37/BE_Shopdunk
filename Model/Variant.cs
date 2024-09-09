using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;

namespace BE_Shopdunk.Model
{
    public class Variant
    {
        [BsonElement("color")]
        [BsonRequired]
        public string? Color { get; set; }

        [BsonRequired]
        [BsonElement("images")]
        public List<string>? Images { get; set; }

        [BsonRequired]
        [BsonElement("memory_options")]
        public List<MemoryOption>? MemoryOptions { get; set; }
    }
}   