using EmployeeProject.Models;

namespace EmployeeProject.Services;

public interface IEmployeeService
{
    Task<int> CreateEmployeeAndReference(Employee employee);
    Task<List<Employee>> GetEmployeeByCompanyList(int companyid);
    Task<List<Employee>> GetEmployeeByDepartamentList(int departamentId);
    Task<Employee> UpdateEmployeeAndReference(Employee employee);
    Task DeleteEmployeeAndReference(int key);
}