using ExpenseTracking.Application.Commands.Budget;
using ExpenseTracking.Application.Handler;
using ExpenseTracking.Application.Services;
using ExpenseTracking.Domain.Repositories;
using ExpenseTracking.Infrastructure.Context;
using ExpenseTracking.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ExpenseTracking.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSQLDB(configuration);
        return services;
    }
    private static IServiceCollection AddSQLDB(this IServiceCollection services, IConfiguration configuration)
    {
        //services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddTransient<IUnitOfWork, UnitOfWork>();
        //services.AddScoped<IBudgetRepository, BudgetRepository>();
        //services.AddScoped<IExpenseRepository, ExpenseRepository>();

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