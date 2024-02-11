using EmployeeProject.Models;

namespace EmployeeProject.Interfaces.Repositories;

public interface IEmployeeRepository
{
    Task<int> CreateEmployee(Employee employee);
    Task<List<Employee>> GetEmployeesByCompany(int companyid);
    Task<List<Employee>> GetEmployeesByDepartament(int departamentId);
    Task<Employee> UpdateEmployee(Employee employee);
    Task DeleteEmployee(int key);
}