using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE_Shopdunk.Data;
using BE_Shopdunk.Dtos.ProductDto;
using BE_Shopdunk.Interface;
using BE_Shopdunk.Mappers;
using BE_Shopdunk.Model;
using MongoDB.Bson;
using MongoDB.Driver;

namespace BE_Shopdunk.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IMongoCollection<Product> _product;
        private readonly IMongoCollection<Category> _category;
        public ProductRepository(MongoDBContext context)
        {
            _product = context.Products;
            _category = context.Categorys;
        }

        public async Task<PagedResult<Product, ProductBannerDto>?> GetPagedProductsByCategoryAsync(ObjectId categoryId, int pageNumber, int pageSize)
        {
            try
            {
                var category = await _category.Find(c => c.Id == categoryId).FirstOrDefaultAsync();
                if (category == null) return null;
                var totalCount = await _product.CountDocumentsAsync(data => data.CategoryId == categoryId);
                var items = await _product.Find(p => p.CategoryId == categoryId)
               .Skip((pageNumber - 1) * pageSize)
               .Limit(pageSize)
               .ToListAsync();

                return new PagedResult<Product, ProductBannerDto>
                {
                    TotalCount = (int)totalCount,
                    CategoryName = category.Name, // Gán tên danh mục vào DTO
                    Items = items.Select(i =>
                     {
                         var dto = i.toProductBannerDto();
                         return dto;
                     }).ToList(),
                };
            }
            catch (Exception ex)
            {
                throw new Exception("Error get product by Category");
            }

        }

        public async Task ProductCreateAsync(Product product)
        {
            try
            {
                await _product.InsertOneAsync(product);

            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred and a new product cannot be created");
            }
        }
        public async Task<Product> ProductGetByIDAsync(ObjectId id)
        {
            try
            {
                var product = await _product.Find(p => p.Id == id).FirstOrDefaultAsync();
                return product;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
        }
        public async Task<List<PagedResult<Product, ProductBannerDto>?>> GetAllProductsByCategoryAsync(int pageNumber, int pageSize)
        {
            var categories = await _category.Find(_ => true).ToListAsync();
            var results = new List<PagedResult<Product, ProductBannerDto>?>();

            foreach (var category in categories)
            {
                var totalCount = await _product.CountDocumentsAsync(p => p.CategoryId == category.Id);
                var items = await _product.Find(p => p.CategoryId == category.Id)
                    .Skip((pageNumber - 1) * pageSize)
                    .Limit(pageSize)
                    .ToListAsync();

                var pagedResult = new PagedResult<Product, ProductBannerDto>
                {
                    TotalCount = (int)totalCount,
                    CategoryName = category.Name,
                    CategoryId = category.Id.toString()
                    Items = items.Select(i =>
                    {
                        var dto = i.toProductBannerDto();
                        return dto;
                    }).ToList(),
                };
                if (pagedResult.Items.Count() > 0)
                    results.Add(pagedResult);
            }

            return results;
        }
    }
}