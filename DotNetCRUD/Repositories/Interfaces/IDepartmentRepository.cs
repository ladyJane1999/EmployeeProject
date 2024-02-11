using EmployeeProject.Models;

namespace EmployeeProject.Interfaces.Repositories
{
    public interface IDepartmentRepository
    {
        public Task<int> CreateDepartament(Department departament);
        public Task<Department> UpdateDepartament(Department departament);
        public Task DeleteDepartment(int id);
    }
}
