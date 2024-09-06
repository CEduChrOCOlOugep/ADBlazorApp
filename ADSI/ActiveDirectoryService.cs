using Dapper;
using Microsoft.Data.SqlClient;

public class ActiveDirectoryService
{
    private readonly string _connectionString;

    public ActiveDirectoryService(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    public async Task<IEnumerable<User>> GetActiveDirectoryUsersAsync()
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            var query = @"
                SELECT Name, SN, GivenName, Mail, sAMAccountName 
                FROM OPENQUERY(ADSI, 
                'SELECT Name, SN, GivenName, Mail, sAMAccountName 
                FROM ''LDAP://DC=yourdomain,DC=com'' 
                WHERE objectClass = ''User''')";

            var users = await connection.QueryAsync<User>(query);
            return users;
        }
    }
}

public class User
{
    public string Name { get; set; }
    public string SN { get; set; }
    public string GivenName { get; set; }
    public string Mail { get; set; }
    public string SAMAccountName { get; set; }
}