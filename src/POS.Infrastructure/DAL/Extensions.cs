using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using POS.Domain.DAL;
using POS.Application.Repositories;
using POS.Infrastructure.Options;
using POS.Infrastructure.DAL.Decorators;
using POS.Infrastructure.DAL.Repositories;

namespace POS.Infrastructure.DAL;

public static class Extensions
{
    private const string OptionsSectionName = "postgres";
    private const string OptionsSectionName2 = "sqlite";

    public static IServiceCollection AddPostgres(this IServiceCollection services,
                                                 IConfiguration configuration)
    {
        services.Configure<PostgresOptions>(configuration.GetRequiredSection("postgres"));
        var postgresOptions = configuration.GetOptions<PostgresOptions>(OptionsSectionName);

        services.AddDbContext<POSDbContext>(x =>
        {
            x.UseNpgsql(postgresOptions.ConnectionString)
               .UseSnakeCaseNamingConvention();
        }
        );

        // Add repositories
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        // Try to apply the unit of work for the request handler.
        services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
        services.TryDecorate(typeof(IRequestHandler<,>), typeof(UnitOfWorkHandlerDecorator<,>));

        // EF Core + Npsql issue
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

        return services;
    }

    public static IServiceCollection AddSQLites(this IServiceCollection services,
                                                 IConfiguration configuration)
    {
        services.Configure<SQLiteOptions>(configuration.GetRequiredSection("sqlite"));
        var sqliteOptions = configuration.GetOptions<SQLiteOptions>(OptionsSectionName2);

        services.AddDbContext<POSDbContext>(x =>
        {
            x.UseSqlite(sqliteOptions.ConnectionString);
        });

        // Try to apply the unit of work for the request handler.
        services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
        services.TryDecorate(typeof(IRequestHandler<,>), typeof(UnitOfWorkHandlerDecorator<,>));

        // Add Repositories
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IItemRepository, ItemRepository>();
        services.AddScoped<ILineItemRepository, LineItemRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();

        return services;
    }
}
