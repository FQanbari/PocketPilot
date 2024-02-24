using ExpenseTracking.Domain.Entities;
using ExpenseTracking.Infrastructure.Repositories;

namespace ExpenseTracking.Application.Services;

public interface IUnitOfWork : IDisposable
{
    Task SaveChanges();
    Task Commit();
    Task Rollback();
    IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class, IEntity, new();
}
