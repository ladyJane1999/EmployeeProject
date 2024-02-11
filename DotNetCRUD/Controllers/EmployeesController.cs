using EmployeeProject.Interfaces.Repositories;
using EmployeeProject.Models;
using EmployeeProject.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeProject.Controllers;

[ApiController]
[Route("[controller]")]
public class EmployeesController : Controller
{
    private readonly IEmployeeRepository _employeeService;

    public EmployeesController(IEmployeeRepository employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpGet("[action]/{departamentId:int}")]
    public async Task<List<Employee>> GetEmployeesByDepartament(int departamentId)
    {
        var result = await _employeeService.GetEmployeesByDepartament(departamentId);

        return result;
    }

    [HttpGet("{companyId:int}")]
    public async Task<List<Employee>> GetEmployeesByCompany(int companyId)
    {
        var result =  await _employeeService.GetEmployeesByCompany(companyId);

        return result;
    }
    
    [HttpPost]
    public async Task<int> AddEmployee([FromBody]Employee employee)
    {
        var result = await _employeeService.CreateEmployee(employee);

        return result;
        
    }
    
    [HttpPut]
    public async Task<Employee> UpdateEmployee([FromBody]Employee employee)
    {
        var result =  await _employeeService.UpdateEmployee(employee);

        return result;
    }
    
    [HttpDelete("{employeeId:int}")]
    public async Task DeleteEmployee(int employeeId)
    {
        await _employeeService.DeleteEmployee(employeeId);
    }
}