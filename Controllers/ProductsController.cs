using BE_Shopdunk.Dtos.ProductDto;
using Microsoft.AspNetCore.Mvc;

namespace BE_Shopdunk.Controller
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        // public async Task<IActionResult> GetAllProduct()
        // {
        //     return
        // }
        [HttpPost("create")]
        public async Task<IActionResult> ProductCreate([FromForm] ProductCreateDto product)
        {
            try
            {
                await _
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}