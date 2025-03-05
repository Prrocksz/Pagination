using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Pagination.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class ReportController : ControllerBase
{
    [HttpGet]
    [Produces("application/json")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public IActionResult ReverseString(string value)
    {
        var result = string.Empty;
        if (string.IsNullOrWhiteSpace(value))
        {
            return NotFound();
        }

        for (int i = value.Length-1; i >= 0; i--)
        {
            result += value[i];
        }
        return Ok(result);
    }
}