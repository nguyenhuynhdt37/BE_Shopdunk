using System.Security.Claims;
using BE_Shopdunk.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace BE_Shopdunk.Controller
{
    [ApiController]
    [Route("api/category")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepo;
        public CategoryController(ICategoryRepository categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }
        [Authorize]
        [HttpPost("create")]
        public async Task<IActionResult> CategoryCreate([FromBody] string? CategoryName)
        {
            var User_ID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (CategoryName == null || User_ID == null)
                return NotFound();
            if (await _categoryRepo.isCategoryAsync(CategoryName))
                return Conflict("Category with this name already exists.");
            await _categoryRepo.CategoryCreateAsync(CategoryName, new ObjectId(User_ID));
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryByID([FromRoute] string id)
        {
            try
            {
                var ObjectID = new ObjectId(id);
                var category = await _categoryRepo.getCatgoryByID(ObjectID);
                if (category == null) return NotFound();
                return Ok(category);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}