using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;

namespace BE_Shopdunk.Dtos.Category
{
    public class CategoryCreateDto
    {
        [BsonRequired]
        public string? Name { get; set; }
    }
}