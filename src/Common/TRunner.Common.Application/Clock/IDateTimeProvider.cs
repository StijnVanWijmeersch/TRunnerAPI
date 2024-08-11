using System.Data.Common;

namespace TRunner.Common.Application.Clock;
public interface IDateTimeProvider
{
    public ValueTask<DbConnection> OpenConnectionAsync(CancellationToken cancellationToken = default);
}
