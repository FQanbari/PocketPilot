using ExpenseTracking.Domain.Entities;
using ExpenseTracking.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ExpenseTracking.Infrastructure.Repositories;

public class GenericRepository<Entity>(DbSet<Entity> dbSet)
    : IGenericRepository<Entity> where Entity : class, IEntity, new()
{

    public Task Create(Entity Entity, CancellationToken cancellationToken)
        => dbSet.AddAsync(Entity, cancellationToken).AsTask();

    public Task Create(List<Entity> Entites, CancellationToken cancellationToken)
        => dbSet.AddRangeAsync(Entites, cancellationToken);

    public async Task Delete(Entity Entity, CancellationToken cancellationToken)
        => dbSet.Remove(Entity);


    public async Task Delete(List<Entity> KeyGuids, CancellationToken cancellationToken)
        => dbSet.RemoveRange(KeyGuids);

    public async Task Update(Entity Entity, CancellationToken cancellationToken)
        => dbSet.Update(Entity);

    public async Task Update(List<Entity> Entites, CancellationToken cancellationToken)
        => dbSet.UpdateRange(Entites);

    public Task<bool> Existing(Expression<Func<Entity, bool>> predicate, CancellationToken cancellationToken)
        => dbSet.AnyAsync(predicate, cancellationToken);


    public Task<List<Entity>> GetAll(CancellationToken cancellationToken)
        => dbSet.AsNoTracking().ToListAsync(cancellationToken);

    public Task<Entity> Find(Expression<Func<Entity, bool>> predicate, CancellationToken cancellationToken)
        => dbSet.FirstAsync(predicate, cancellationToken);

    public Task<List<Entity>> GetList(Expression<Func<Entity, bool>> predicate, CancellationToken cancellationToken)
        => dbSet.AsNoTracking().Where(predicate).ToListAsync(cancellationToken);

    public Task<int> Count(Expression<Func<Entity, bool>> predicate, CancellationToken cancellationToken)
        => dbSet.CountAsync(predicate, cancellationToken);

    public Task<int> CountAll(CancellationToken cancellationToken)
        => dbSet.CountAsync(cancellationToken);

    public Task<List<Entity>> GetListPaging(Expression<Func<Entity, bool>> predicate, CancellationToken cancellationToken, int pageSize = 10, int pageNumber = 1)
        => dbSet.AsNoTracking().Where(predicate).Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToListAsync(cancellationToken);
}
