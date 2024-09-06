using System.Security.Claims;
using BE_Shopdunk.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BE_Shopdunk.Controller
{
    [Authorize]
    [ApiController]
    [Route("api/category")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepo;
        public CategoryController(ICategoryRepository categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }
        [HttpPost("create")]
        public async Task<IActionResult> CategoryCreate([FromBody] string? CategoryName)
        {
            var User_ID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (CategoryName == null || User_ID == null)
                return NotFound();
            if (await _categoryRepo.isCategoryAsync(CategoryName))
                return Conflict("Category with this name already exists.");
            await _categoryRepo.CategoryCreateAsync(CategoryName, User_ID);
            return Ok();

        }
    }
}