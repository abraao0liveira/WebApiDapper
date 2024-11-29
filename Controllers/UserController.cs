using Microsoft.AspNetCore.Mvc;
using WebApiDapper.DTO;
using WebApiDapper.Services;

namespace WebApiDapper.Controllers
{
  [Route("api/[controller]")]
  [ApiController]

  public class UserController : ControllerBase
  {
    private readonly IUser _userInterface;
    public UserController(IUser userInterface)
    {
      _userInterface = userInterface;
    }

    [HttpGet("list")]
    public async Task<IActionResult> ListUsers()
    {
      var users = await _userInterface.ListUsers();

      if (users.Status == false)
      {
        return NotFound(users); //404
      }

      return Ok(users); //200
    }

    [HttpGet("{userId}")]
    public async Task<IActionResult> ListUserId(int userId)
    {
      var user = await _userInterface.ListUserId(userId);

      if (user.Status == false)
      {
        return NotFound(user); //404
      }

      return Ok(user); //200
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateUser(UserCreateDTO userCreateDTO)
    {
      var users = await _userInterface.CreateUser(userCreateDTO);

      if (users.Status == false)
      {
        return BadRequest(users); //400
      }

      return Ok(users); //200
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateUser(UserUpdateDTO userUpdateDTO)
    {
      var users = await _userInterface.UpdateUser(userUpdateDTO);

      if (users.Status == false)
      {
        return BadRequest(users); //400
      }

      return Ok(users); //200
    }
  }
}