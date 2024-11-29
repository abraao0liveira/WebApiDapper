using Microsoft.AspNetCore.Mvc;
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

    [HttpGet]
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
  }
}