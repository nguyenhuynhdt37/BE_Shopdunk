using System.Security.Claims;
using BE_Shopdunk.Dtos.ProductDto;
using BE_Shopdunk.Interface;
using BE_Shopdunk.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace BE_Shopdunk.Controller
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepo;
        private readonly ICategoryRepository _categoryRepo;

        public ProductController(IProductRepository productRepo)
        {
            _productRepo = productRepo;
        }
        // [Authorize]
        // [HttpPost("create")]
        // public async Task<IActionResult> ProductCreate([FromForm] ProductCreateDto product)
        // {
        //     if (product == null) return NotFound();
        //     try
        //     {
        //         var productModel = product.dto();
        //         string supplier_id = User.FindFirstValue(ClaimTypes.NameIdentifier);
        //         productModel.SupplierId = new ObjectId(supplier_id);
        //         await _productRepo.ProductCreateAsync(productModel);
        //         return Ok();
        //     }
        //     catch (Exception ex)
        //     {
        //         return StatusCode(500, ex.Message);
        //     }
        // }
        [HttpGet("{id}")]
        public async Task<IActionResult> ProductGetByID([FromRoute] string? id)
        {
            if (id == null) return NotFound();
            try
            {
                var idModel = new ObjectId(id);
                var product = await _productRepo.ProductGetByIDAsync(idModel);
                if (product == null) return NotFound();
                return Ok(product.ToProductDto());
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error: " + ex.Message);
            }
        }
        [HttpGet]
        [Route("category/{categoryId}")]
        public async Task<IActionResult> GetProductsByCategory([FromRoute] string categoryId, int pageNumber = 1, int pageSize = 10)
        {
            if (string.IsNullOrEmpty(categoryId)) return BadRequest("Category ID is required.");
            try
            {
                var categoryObjectId = new ObjectId(categoryId);
                var products = await _productRepo.GetPagedProductsByCategoryAsync(categoryObjectId, pageNumber, pageSize);
                if (products == null) return NotFound("No products found for this category.");
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error: " + ex.Message);
            }
        }
        [HttpGet]
        [Route("category/product_all")]
        public async Task<IActionResult> GetAllProductsByCategory(int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                var products = await _productRepo.GetAllProductsByCategoryAsync(pageNumber, pageSize);
                if (products == null) return NotFound("No products found for this category.");
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error: " + ex.Message);
            }
        }
    }
}