using EmployeeProject.Models;

namespace EmployeeProject.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IDbService _dbService;

    public EmployeeService(IDbService dbService)
    {
        _dbService = dbService;
    }

    public async Task<int> CreateEmployeeAndReference(Employee employee)
    {
        if (employee == null) throw new ArgumentNullException(nameof(employee));

        var saveEmployee =
            await _dbService.EditData(
                "INSERT INTO public.employee (id,name, surname, phone, companyId, passportId) VALUES (@Id, @Name, @Surname, @Phone, @CompanyId, @PassportId, @DepartamentId)",
                employee);

        var savePassport = _dbService.EditData(
                  "INSERT INTO public.passport (number, type) VALUES (@Number, @Type)",
                  employee.Passport);

        var saveDepartament = _dbService.EditData(
                  "INSERT INTO public.department (name, phone) VALUES (@Name, @Phone)",
                  employee.Department);

        return employee.Id;
    }

    public async Task<List<Employee>> GetEmployeeByDepartamentList(int departamentId)
    {
        var employeeList = await _dbService.GetAsync<Employee>("SELECT * FROM public.employee where departamentId=@DepartamentId", new { });
        return employeeList;
    }


    public async Task<List<Employee>> GetEmployeeByCompanyList(int companyId)
    {
        var employeeList = await _dbService.GetAsync<Employee>("SELECT * FROM public.employee where companyId=@CompanyId", new { });
        return employeeList;
    }

    public async Task<Employee> UpdateEmployeeAndReference(Employee employee)
    {
        if (employee == null) throw new ArgumentNullException(nameof(employee));

        var updateEmployee =
            await _dbService.EditData(
                "Update public.employee SET name=@Name, surname=@Surname, phone=@Phone, companyId=@CompanyId WHERE id=@Id",
                employee);

        var updatePassport = _dbService.EditData(
                  "Update public.passport SET number=@Number, type=@Type WHERE id=@Passport.Id",
                  employee.Passport);

        var updateDepartament = _dbService.EditData(
                  "Update public.department SET name=@Name, phone=@Phone WHERE id=@Department.Id",
                  employee.Department);

        return employee;
    }

    public async Task DeleteEmployeeAndReference(int id)
    {
        await _dbService.EditData("DELETE FROM public.employee WHERE id=@Id", new {id});
    }
}