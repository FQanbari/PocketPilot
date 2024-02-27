using ExpenseTracking.Application.Services;
using ExpenseTracking.Domain.Entities;
using ExpenseTracking.Domain.Repositories;
using ExpenseTracking.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace ExpenseTracking.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    private readonly IDbContextTransaction transaction;
    private readonly Dictionary<Type, object> _repositories;
    public UnitOfWork(AppDbContext context)
    {
        _context = context;
        transaction = context.Database.BeginTransaction();
        _context.Database.EnsureCreated();
        _repositories = new Dictionary<Type, object>();
    }

    public async Task Commit()
    {
        await _context.SaveChangesAsync();
        await transaction.CommitAsync();
    }

    public async Task Dispose()
    {
        await transaction.DisposeAsync();
        await _context.DisposeAsync();
    }

    public async Task Rollback()
    {
        await transaction.RollbackAsync();
    }

    public async Task Save()
    {
        await _context.SaveChangesAsync();
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }

    void IDisposable.Dispose()
    {
        transaction.Dispose();
        _context.Dispose();
    }
    public TRepository GetRepository<TRepository, TEntity>()
        where TRepository : class
        where TEntity : class, IEntity, new()
    {
        if (_repositories.ContainsKey(typeof(TRepository)))
        {
            return (TRepository)_repositories[typeof(TRepository)];
        }

        var repository = Activator.CreateInstance(typeof(TRepository), _context.Set<TEntity>());
        _repositories.Add(typeof(TRepository), repository);
        return (TRepository)repository;
    }
    IGenericRepository<TEntity> IUnitOfWork.GetRepository<TEntity>()
    {
        if (_repositories.ContainsKey(typeof(TEntity)))
        {
            return (IGenericRepository<TEntity>)_repositories[typeof(TEntity)];
        }

        var repository = new GenericRepository<TEntity>(_context.Set<TEntity>());
        _repositories.Add(typeof(TEntity), repository);
        return repository;
    }

    async Task IUnitOfWork.SaveChanges()
    {
        await _context.SaveChangesAsync();
    }
}
