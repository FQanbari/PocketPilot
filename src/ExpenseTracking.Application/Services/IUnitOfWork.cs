using ExpenseTracking.Domain.Entities;
using ExpenseTracking.Domain.Repositories;
using ExpenseTracking.Infrastructure.Repositories;

namespace ExpenseTracking.Application.Services;

public interface IUnitOfWork : IDisposable
{
    Task SaveChanges();
    Task Commit();
    Task Rollback();
    TRepository GetRepository<TRepository, TEntity>() 
        where TRepository : class
        where TEntity : class, IEntity, new();
    IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class, IEntity, new();
}
