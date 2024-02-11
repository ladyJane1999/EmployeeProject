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

    [HttpGet("{departamentId:int}")]
    public async Task<List<Employee>> GetEmployeeByDepartamentList(int departamentId)
    {
        var result = await _employeeService.GetEmployeeByDepartamentList(departamentId);

        return result;
    }

    [HttpGet("{companyId:int}")]
    public async Task<List<Employee>> GetEmployeeByCompanyList(int companyId)
    {
        var result =  await _employeeService.GetEmployeeByCompanyList(companyId);

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
    
    [HttpDelete("{employeeId:int}")]
    public async Task DeleteEmployee(int employeeId)
    {
        await _employeeService.DeleteEmployeeAndReference(employeeId);
    }
}