using EmployeeProject.DbContext;
using EmployeeProject.Interfaces.Repositories;
using EmployeeProject.Models;

namespace EmployeeProject.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly IDbContext _dbContext;

        public DepartmentRepository(IDbContext dbService)
        {
            _dbContext = dbService;
        }

        public async Task<int> CreateDepartament(Department departament)
        {
            if (departament == null) throw new ArgumentNullException(nameof(departament));

            await _dbContext.EditData(
                      "INSERT INTO public.department (name, phone) VALUES (@Name, @Phone)",
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
