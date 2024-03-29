﻿using EmployeeProject.DbContext;
using EmployeeProject.Interfaces.Repositories;
using EmployeeProject.Models;

namespace EmployeeProject.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly IDbContext _dbContext;

    public EmployeeRepository(IDbContext dbService)
    {
        _dbContext = dbService;
    }

    public async Task<int> CreateEmployee(Employee employee)
    {
        if (employee == null) throw new ArgumentNullException(nameof(employee));

        await _dbContext.EditData(
                "INSERT INTO public.employee (name, surname, phone, companyId) VALUES (@Name, @Surname, @Phone, @CompanyId)",
                employee);

        await _dbContext.EditData(
                "INSERT INTO public.passport (number, type) VALUES (@Number, @Type)",
                employee.Passport);

        return employee.Id;
    }

    public async Task<List<Employee>> GetEmployeesByDepartament(int departamentId)
    {
        var employeeList = await _dbContext.GetAsync<Employee>("SELECT * FROM public.employee where id=@departamentId", new { departamentId });
        return employeeList;
    }


    public async Task<List<Employee>> GetEmployeesByCompany(int companyId)
    {
        var employeeList = await _dbContext.GetAsync<Employee>("SELECT * FROM public.employee where id=@companyId", new { companyId });
        return employeeList;
    }

    public async Task<Employee> UpdateEmployee(Employee employee)
    {
        if (employee == null) throw new ArgumentNullException(nameof(employee));

        await _dbContext.EditData(
                "Update public.employee SET name=@Name, surname=@Surname, phone=@Phone, companyId=@CompanyId WHERE id=@Id",
                employee);

        await _dbContext.EditData(
                 "Update public.passport SET number=@Number, type=@Type WHERE id=@Id",
                 employee.Passport);

        return employee;
    }

    public async Task DeleteEmployee(int id)
    {
        await _dbContext.EditData("DELETE FROM public.employee WHERE id=@Id", new {id});
    }
}