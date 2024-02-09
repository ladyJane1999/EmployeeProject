namespace EmployeeProject.Services;

public interface IDbService
{
    Task<List<T>> GetAsync<T>(string command, object parms); 
    Task<int> EditData(string command, object parms);
}