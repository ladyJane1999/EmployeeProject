using Dapper;
using Npgsql;
using System.Data;


namespace EmployeeProject.DbContext
{
    public class DbContext : IDbContext
    {
        private readonly IDbConnection _db;

        public DbContext(IConfiguration configuration)
        {
            _db = new NpgsqlConnection(configuration.GetConnectionString("Employeedb"));
        }

        public async Task<List<T>> GetAsync<T>(string command, object parms)
        {
            List<T> result = new List<T>();

            result = (await _db.QueryAsync<T>(command, parms)).ToList();

            return result;

        }

        public async Task<int> EditData(string command, object parms)
        {
            int result;

            result = await _db.ExecuteAsync(command, parms);

            return result;
        }
    }
}
