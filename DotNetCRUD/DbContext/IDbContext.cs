namespace EmployeeProject.DbContext;

public interface IDbContext
{
    Task<List<T>> GetAsync<T>(string command, object parms); 
    Task<int> EditData(string command, object parms);
}