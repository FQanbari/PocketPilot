using ExpenseTracking.Domain.Repositories;
using ExpenseTracking.Infrastructure.Context;
using ExpenseTracking.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ExpenseTracking.Infrastructure;

internal static class Extensions
{
    public static IServiceCollection AddSQLDB(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IBudgetRepository, BudgetRepository>();
        services.AddScoped<IExpenseRepository, ExpenseRepository>();
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

        var options = configuration.GetOptions<ConnectionStringOptions>("ConnectionString");
        services.AddDbContext<AppDbContext>(ctx =>
        ctx.UseSqlServer(options.AppDbContext));

        return services;
    }
    public static TOptions GetOptions<TOptions>(this IConfiguration configuration, string sectionName)
        where TOptions : new()
    {
        var options = new TOptions();
        configuration.GetSection(sectionName).Bind(options);
        return options;
    }
}