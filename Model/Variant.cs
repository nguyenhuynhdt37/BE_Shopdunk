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
        public string? Color { get; set; }

        [BsonElement("images")]
        public List<string>? Images { get; set; }

        [BsonElement("memory_options")]
        public List<MemoryOption>? MemoryOptions { get; set; }
    }
}