﻿using EmployeeProject.DbContext;
using EmployeeProject.Models;

namespace EmployeeProject.Repositories
{
    public class DepartamentRepository : IDepartamentRepository
    {
        private readonly IDbContext _dbContext;

        public DepartamentRepository(IDbContext dbService)
        {
            _dbContext = dbService;
        }

        public async Task<int> CreateDepartament(Department departament)
        {
            if (departament == null) throw new ArgumentNullException(nameof(departament));

            await _dbContext.EditData(
                      "INSERT INTO public.department (id, name, phone) VALUES (@Id,@Name, @Phone)",
                      departament);

            return departament.Id;
        }

        public async Task DeleteDepartment(int id)
        {
            await _dbContext.EditData("DELETE FROM public.department WHERE id=@Id", new { id });
        }

        public async Task<Department> UpdateDepartament(Department departament)
        {
            if (departament == null) throw new ArgumentNullException(nameof(departament));

            await _dbContext.EditData(
                      "Update public.department SET name=@Name, phone=@Phone WHERE id=@Id",
                      departament);

            return departament;
        }
    }
}