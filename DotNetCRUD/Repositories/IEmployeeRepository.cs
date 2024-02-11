using EmployeeProject.Models;

namespace EmployeeProject.Repositories;

public interface IEmployeeRepository
{
    Task<int> CreateEmployee(Employee employee);
    Task<List<Employee>> GetEmployeesCompany(int companyid);
    Task<List<Employee>> GetEmployeesDepartament(int departamentId);
    Task<Employee> UpdateEmployee(Employee employee);
    Task DeleteEmployee(int key);
}