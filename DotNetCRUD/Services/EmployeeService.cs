using EmployeeProject.Models;

namespace EmployeeProject.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IDbService _dbService;

    public EmployeeService(IDbService dbService)
    {
        _dbService = dbService;
    }

    public async Task<int> CreateEmployee(Employee employee)
    {
        var saveEmployee =
            await _dbService.EditData(
                "INSERT INTO public.employee (id,name, surname, phone, companyId, passportId) VALUES (@Id, @Name, @Surname, @Phone, @CompanyId, @PassportId, @DepartamentId)",
                employee);

        var savePassport = _dbService.EditData(
                  "INSERT INTO public.passport (id,number, type) VALUES (@Id, @Number, @Type)",
                  employee.Passport);

        var saveDepartament = _dbService.EditData(
                  "INSERT INTO public.department (id,name, phone) VALUES (@Id, @Name, @Phone)",
                  employee.Department);

        return employee.Id;
    }

    public async Task<List<Employee>> GetEmployeeList(int departamentId)
    {
        var employeeList = await _dbService.GetAsync<Employee>("SELECT * FROM public.employee where departamentId=@DepartamentId", new { });
        return employeeList;
    }


    public async Task<List<Employee>> GetEmployee(int companyId)
    {
        var employeeList = await _dbService.GetAsync<Employee>("SELECT * FROM public.employee where companyId=@CompanyId", new { });
        return employeeList;
    }

    public async Task<Employee> UpdateEmployee(Employee employee)
    {
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

    public async Task DeleteEmployee(int id)
    {
        await _dbService.EditData("DELETE FROM public.employee WHERE id=@Id", new {id});
    }
}