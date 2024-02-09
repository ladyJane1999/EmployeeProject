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
    public async Task<List<Employee>> GetEmployeeByDepartamentList(int id)
    {
        var result = await _employeeService.GetEmployeeByDepartamentList(id);

        return result;
    }

    [HttpGet("{id:int}")]
    public async Task<List<Employee>> GetEmployeeByCompanyList(int id)
    {
        var result =  await _employeeService.GetEmployeeByCompanyList(id);

        return result;
    }
    
    [HttpPost]
    public async Task<int> AddEmployee([FromBody]Employee employee)
    {
        var result = await _employeeService.CreateEmployeeAndReference(employee);

        return result;
        
    }
    
    [HttpPut]
    public async Task<Employee> UpdateEmployee([FromBody]Employee employee)
    {
        var result =  await _employeeService.UpdateEmployeeAndReference(employee);

        return result;
    }
    
    [HttpDelete("{id:int}")]
    public async Task DeleteEmployee(int id)
    {
        await _employeeService.DeleteEmployeeAndReference(id);
    }
}