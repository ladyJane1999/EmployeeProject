using EmployeeProject.Models;
using EmployeeProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeProject.Controllers;

[ApiController]
[Route("[controller]")]
public class EmployeesController : Controller
{
    private readonly IEmployeeService _employeeService;

    public EmployeesController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetEmployee(int id)
    {
        var result =  await _employeeService.GetEmployee(id);

        return Ok(result);
    }
    
    [HttpPost]
    public async Task<IActionResult> AddEmployee([FromBody]Employee employee)
    {
        if (employee == null) Results.BadRequest();

        var result = await _employeeService.CreateEmployee(employee);

        return Ok(result);
        
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateEmployee([FromBody]Employee employee)
    {
        if (employee == null) Results.BadRequest();

        var result =  await _employeeService.UpdateEmployee(employee);

        return Ok(result);
    }
    
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteEmployee(int id)
    {
        await _employeeService.DeleteEmployee(id);

        return Ok();
    }
}