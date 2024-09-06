using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE_Shopdunk.Dtos.ProductDto;
using BE_Shopdunk.Model;
using MongoDB.Bson;
using MongoDB.Driver;

namespace BE_Shopdunk.Mappers
{
    public static class ProductMapper
    {
        public static Product ProductCreateDtoToProduct(this ProductCreateDto product)
        {
            var _product = new Product
            {
                Name = product.Name,
                CategoryId = new ObjectId(product.CategoryId),
                Variants = product.Variants
            };
            return _product;
        }
    }
}