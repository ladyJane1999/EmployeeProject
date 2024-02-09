using EmployeeProject.Models;

namespace EmployeeProject.Services;

public interface IEmployeeService
{
    Task<int> CreateEmployee(Employee employee);
    Task<List<Employee>> GetEmployee(int companyid);
    Task<List<Employee>> GetEmployeeList(int departamentId);
    Task<Employee> UpdateEmployee(Employee employee);
    Task DeleteEmployee(int key);
}