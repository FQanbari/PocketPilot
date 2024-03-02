using ExpenseTracking.Application.Services;
using ExpenseTracking.Domain.Entities;
using ExpenseTracking.Domain.Repositories;
using ExpenseTracking.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Reflection;

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
    public void SaveChanges()
    {
        _context.SaveChanges();
    }

    public void Commit()
    {
        _context.SaveChanges();
        transaction.Commit();
    }

    public void Rollback()
    {
        transaction.Rollback();
    }
    public void Dispose()
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

        var implementations = Assembly.GetExecutingAssembly().GetTypes()
            .Where(type => typeof(TRepository).IsAssignableFrom(type) && !type.IsInterface).FirstOrDefault();

        var repository = Activator.CreateInstance(implementations, _context.Set<TEntity>());
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

    //async Task IUnitOfWork.SaveChanges()
    //{
    //    await _context.SaveChangesAsync();
    //}
}
