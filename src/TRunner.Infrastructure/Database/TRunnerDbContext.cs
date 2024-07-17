using Microsoft.EntityFrameworkCore;

namespace TRunner.Infrastructure.Database;

internal sealed class TRunnerDbContext(DbContextOptions<TRunnerDbContext> options) : DbContext(options)
{
 
}
