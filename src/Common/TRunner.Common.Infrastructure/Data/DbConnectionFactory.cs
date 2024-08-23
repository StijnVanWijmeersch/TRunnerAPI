using System.Data.Common;
using TRunner.Common.Application.Data;

namespace TRunner.Common.Infrastructure.Data;
internal class DbConnectionFactory(DbDataSource connection) : IDbConnectionFactory
{
    public async ValueTask<DbConnection> OpenConnectionAsync()
    {
        return await connection.OpenConnectionAsync();
    }
}
