using Dapper;
using Microsoft.Data.SqlClient;

namespace ADSI.Services;

public class DatabaseService
{
    private readonly string _connectionString;

    public DatabaseService(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    public async Task<IEnumerable<User>> GetUsersAsync()
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            var query = "SELECT * FROM Users"; // Example query
            var users = await connection.QueryAsync<User>(query);
            return users;
        }
    }

    // CRUD methods here
}