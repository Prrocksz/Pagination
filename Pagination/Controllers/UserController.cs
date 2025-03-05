using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pagination.Common;
using Pagination.Models;

namespace Pagination.Controllers;

[Route("api/[controller]")]
public class UserController : Controller
{
    private  readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    
    [HttpPost]
    [Route("Create")]
    public IActionResult AddUsers([FromBody]Users users)
    {
        try
        {
            _userService.AddUsers(users);
            return Ok("Success User Added");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpGet]
    [Authorize]
    [Produces("application/json")]
    public List<Users> Users()
    {
        var result =_userService.GetUsers();
        return result;
    }
}