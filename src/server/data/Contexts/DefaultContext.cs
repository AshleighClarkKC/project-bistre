using Bistre.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bistre.Data.Contexts;

public class DefaultContext(DbContextOptions<DefaultContext> options) : DbContext(options)
{
    public DbSet<LookupEntity> Lookups { get; set; }
}
