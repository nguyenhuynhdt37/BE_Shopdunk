using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BE_Shopdunk.Controller
{
    [Authorize]
    [ApiController]
    [Route("api/category")]
    public class CategoryController : ControllerBase
    {
        [HttpPost("create")]
        public async Task<IActionResult> CategoryCreate([FromBody] string? CategoryName)
        {
            if (CategoryName == null)
                return NotFound();

        }
    }
}