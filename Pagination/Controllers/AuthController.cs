using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Pagination.Models;

namespace Pagination.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : Controller
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly AuthService _authService;

    public AuthController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, AuthService authService)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _authService = authService;
    }
    
    [HttpPost("Register")]
    public async Task<IActionResult> Register([FromBody] RegisterModel model)
    {
        var userExists = await _userManager.FindByNameAsync(model.Username);
        if (userExists != null)
            return BadRequest(new { message = "Username already exists!" });
        
        var user = new IdentityUser { UserName = model.Username, Email = model.Email };
        var result = await _userManager.CreateAsync(user, model.Password);

        if (!result.Succeeded)
            return BadRequest(result.Errors);

        return Ok(new { message = "User created successfully!" });
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] LoginModel model)
    {
        var user = await _userManager.FindByNameAsync(model.Username);
        if(user == null || ! await _userManager.CheckPasswordAsync(user, model.Password))
        {
            return Unauthorized(new { message = "Invalid credentials" });
        }
        var token = await _authService.GenerateToken(user);
        return Ok( new {token});
    }
    

    [HttpGet("secure-validate-token")]
    public IActionResult SecureValidateToken()
    {
        var identity = HttpContext.User.Identity;

        if (identity == null || !identity.IsAuthenticated)
        {
            return Unauthorized(new { message = "Invalid token in [Authorize] context" });
        }

        return Ok(new { message = "Token is valid!", user = identity.Name });
    }
    
    [HttpGet("debug-token")]
    public IActionResult DebugToken()
    {
        var identity = HttpContext.User.Identity;

        return Ok(new
        {
            IsAuthenticated = identity?.IsAuthenticated,
            Name = identity?.Name,
            Claims = HttpContext.User.Claims.Select(c => new { c.Type, c.Value })
        });
    }
    
    [HttpGet("test-token")]
    public IActionResult TestToken([FromHeader] string authorization)
    {
        if (string.IsNullOrWhiteSpace(authorization))
        {
            return BadRequest("Missing Authorization header");
        }

        var token = authorization.Replace("Bearer ", "");
        var isValid = _authService.ValidateToken(token);

        return Ok(new { isValid });
    }
}