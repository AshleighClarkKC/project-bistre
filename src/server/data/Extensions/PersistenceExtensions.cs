using Bistre.Data.Contexts;
using Bistre.Data.Contracts.Base;
using Bistre.Data.Repositories;
using Bistre.Entities;
using Bistre.Data.Models.Commands;
using Bistre.Data.Models.Queries;
using LiteBus.Commands.Extensions.MicrosoftDependencyInjection;
using LiteBus.Messaging.Extensions.MicrosoftDependencyInjection;
using LiteBus.Queries.Extensions.MicrosoftDependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Bistre.Data.Repositories.Base;

namespace Bistre.Data.Extensions;

public static class PersistenceExtensions
{
    public static IServiceCollection AddDefaultDataContext(this IServiceCollection svc, Action<DbContextOptionsBuilder>? options = null) 
        => svc.AddDbContext<DefaultContext>(options);

    public static IServiceCollection AddLookupRepository(this IServiceCollection svc)
        => svc
            .AddScoped<IBaseRepository<LookupEntity>, LookupRepository>();

    public static IServiceCollection AddLookupMediator(this IServiceCollection svc)
        => svc.AddLiteBus(
            lb =>
                lb
                .AddCommandModule(mod => mod.RegisterFromAssembly(typeof(CreateLookupCommandModel).Assembly))
                .AddCommandModule(mod => mod.RegisterFromAssembly(typeof(UpdateLookupCommandModel).Assembly))
                .AddCommandModule(mod => mod.RegisterFromAssembly(typeof(DeleteLookupCommandModel).Assembly))
                .AddQueryModule(mod => mod.RegisterFromAssembly(typeof(GetLookupQueryModel).Assembly))
        );
}

