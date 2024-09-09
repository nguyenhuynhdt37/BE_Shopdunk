using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE_Shopdunk.Model;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BE_Shopdunk.Dtos.ProductDto
{
    public class ProductCreateDto
    {
        [BsonRequired]
        public string? Name { get; set; }

        [BsonRequired]
        public string? CategoryId { get; set; }

        [BsonRequired]
        public List<Variant>? Variants { get; set; }
    }
}