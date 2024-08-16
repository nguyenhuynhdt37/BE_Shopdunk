// Controllers/UsersController.cs
using BE_Shopdunk.Dtos;
using BE_Shopdunk.Dtos.User;
using BE_Shopdunk.Interface;
using BE_Shopdunk.Mappers;
using BE_Shopdunk.Model;
using BE_Shopdunk.Repositories;
using BE_Shopdunk.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System.Threading.Tasks;

[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    private readonly JwtTokenGenerator _jwtTokenGenerator;

    public UsersController(IUserRepository userRepository, JwtTokenGenerator jwtTokenGenerator)
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] UserCreateDto user)
    {
        var userModel = user.UserCreateDtoToUser();
        if (await _userRepository.checkUser(userModel.UserName.ToString().ToLower())) return BadRequest("User already exists");
        userModel = await _userRepository.CreateAsync(userModel);
        userModel = await _userRepository.GetByIdAsync(userModel.Id);
        return CreatedAtAction(nameof(GetById), new { id = userModel.Id }, userModel.UserToUserDto());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        var user = await _userRepository.GetByIdAsync(new ObjectId(id));
        if (user == null) return NotFound();
        return Ok(user.UserToUserDto());
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

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> getAllUser()
    {
        var users = await _userRepository.getAllUsersAsync();
        return Ok(users.Select(x => x.UserToUserDto()));
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(UserLoginDto user)
    {
        var userModel = await _userRepository.CheckLoginAsync(user);
        if (userModel == null) return BadRequest("User not found"); // BadRequest
        var token = _jwtTokenGenerator.GenerateJwtToken(userModel);
        return Ok(token);
    }
}
