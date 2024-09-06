using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE_Shopdunk.Data;
using BE_Shopdunk.Dtos.ProductDto;
using BE_Shopdunk.Interface;
using BE_Shopdunk.Mappers;
using BE_Shopdunk.Model;
using MongoDB.Driver;

namespace BE_Shopdunk.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IMongoCollection<Product> _product;
        public ProductRepository(MongoDBContext context)
        {
            _product = context.Products;
        }
        public async Task ProductCreateAsync(Product product)
        {
            try
            {
                return await _product.InsertOneAsync(product);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred and a new product cannot be created");
            }
        }
    }
}