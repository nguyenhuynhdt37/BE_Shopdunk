// Controllers/UsersController.cs
using BE_Shopdunk.Interface;
using BE_Shopdunk.Model;
using BE_Shopdunk.Repositories;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserRepository _userRepository;

    public UsersController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(string id)
    {
        var user = await _userRepository.GetByIdAsync(new ObjectId(id));
        if (user == null) return NotFound();
        return Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] User user)
    {
        await _userRepository.CreateAsync(user);
        return CreatedAtAction(nameof(GetByIdAsync), new { id = user.Id.ToString() }, user);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(string id, [FromBody] User user)
    {
        if (id != user.Id.ToString()) return BadRequest();
        await _userRepository.UpdateAsync(user);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(string id)
    {
        await _userRepository.DeleteAsync(new ObjectId(id));
        return NoContent();
    }
}
