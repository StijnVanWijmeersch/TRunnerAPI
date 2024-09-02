using System.Data.Common;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using TRunner.Common.Application.Data;

namespace TRunner.Common.Infrastructure.Data;
internal class DbConnectionFactory(IConfiguration config) : IDbConnectionFactory
{
    public async ValueTask<DbConnection> OpenConnectionAsync()
    {
        string connectionString = config.GetConnectionString("Database");

        var connection = new SqlConnection(connectionString);

        await connection.OpenAsync();

        return connection;
    }
}
