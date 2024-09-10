using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE_Shopdunk.Dtos.ProductDto;
using BE_Shopdunk.Model;
using MongoDB.Bson;

namespace BE_Shopdunk.Interface
{
    public interface IProductRepository
    {
        public Task ProductCreateAsync(Product product);
        public Task<Product> ProductGetByIDAsync(ObjectId id);
        public Task<PagedResult<Product, ProductBannerDto>?> GetPagedProductsByCategoryAsync(ObjectId categoryId, int pageNumber, int pageSize);
        public Task<List<PagedResult<Product, ProductBannerDto>?>> GetAllProductsByCategoryAsync(int pageNumber, int pageSize);
    }
}