using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using Pagination.Common;

namespace Pagination.Controllers;

[Route("api/[controller]")]
public class Employee : Controller
{
    private readonly REPODB _repodb;

    public Employee(REPODB repodb)
    {
        _repodb = repodb;
    }
    
    /// <summary>
    ///  fetches the Details of Employee
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("get/{id}")]
    public IActionResult FetchDetails(int id)
    {
        var result = _repodb.Employees.OrderByDescending(e => e.Salary)
            .Take(5).ToList();
        return Ok(result);
    }
}