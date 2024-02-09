using System.Data;
using Dapper;
using Npgsql;

namespace EmployeeProject.Services;

public class DbService : IDbService
{
    private readonly IDbConnection _db;

    public DbService(IConfiguration configuration)
    {
        _db = new NpgsqlConnection(configuration.GetConnectionString("Employeedb"));
    }

    public async Task<List<T>> GetAsync<T>(string command, object parms)
    {
        List<T> result = new List<T>();

        result = (await _db.QueryAsync<T>(command, parms).ConfigureAwait(false)).ToList();

        return result;

    }

    public async Task<int> EditData(string command, object parms)
    {
        int result;

        result = await _db.ExecuteAsync(command, parms);

        return result;
    }
}