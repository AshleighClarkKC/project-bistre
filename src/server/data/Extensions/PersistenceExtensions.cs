using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Bistre.Data.Extensions;

public static class PersistenceExtensions
{
    public static IServiceCollection AddDataContext<TContext>(this IServiceCollection svc, Action<DbContextOptionsBuilder>? options = null) where TContext : DbContext
    {
        svc.AddDbContext<TContext>(options);
        return svc;
    }
}

