using Microsoft.EntityFrameworkCore;

namespace Bistre.Data.Contexts;

public class DefaultContext(DbContextOptions<DefaultContext> options) : DbContext(options)
{

}
