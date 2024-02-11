using EmployeeProject.Models;

namespace EmployeeProject.Repositories
{
    public interface IDepartamentRepository
    {
        public Task<int> CreateDepartament(Department departament);
        public Task<Department> UpdateDepartament(Department departament);
        public Task DeleteDepartment(int id);
    }
}
