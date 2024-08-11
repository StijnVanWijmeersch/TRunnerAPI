using System.Data.Common;
using Microsoft.Data.SqlClient;
using TRunner.Common.Application.Data;

namespace TRunner.Common.Infrastructure.Data;
internal class DbConnectionFactory(SqlConnection connection) : IDbConnectionFactory
{
    public async ValueTask<DbConnection> OpenConnectionAsync(CancellationToken cancellationToken = default)
    {
        await connection.OpenAsync(cancellationToken);
        return connection;
    }
}
