using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE_Shopdunk.Model;
using MongoDB.Bson;

namespace BE_Shopdunk.Dtos.ProductDto
{
    public class ProductCreateDto
    {
        public string? Name { get; set; }

        public string? CategoryId { get; set; }

        public List<Variant>? Variants { get; set; }
    }
}