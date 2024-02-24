using ExpenseTracking.Domain.Entities;
using System.Linq.Expressions;

namespace ExpenseTracking.Infrastructure.Repositories;

public interface IGenericRepository<Entity> where Entity : class, IEntity, new()
{

    Task Create(Entity Entity, CancellationToken cancellationToken);

    Task Create(List<Entity> Entites, CancellationToken cancellationToken);

    Task Update(Entity Entity, CancellationToken cancellationToken);

    Task Update(List<Entity> Entites, CancellationToken cancellationToken);

    Task Delete(Entity Entity, CancellationToken cancellationToken);

    Task Delete(List<Entity> KeyGuids, CancellationToken cancellationToken);
    Task<List<Entity>> GetListPaging(Expression<Func<Entity, bool>> predicate, CancellationToken cancellationToken, int pageSize = 10, int pageNumber = 1);

    Task<List<Entity>> GetList(Expression<Func<Entity, bool>> predicate, CancellationToken cancellationToken);

    Task<List<Entity>> GetAll(CancellationToken cancellationToken);

    Task<Entity> Find(Expression<Func<Entity, bool>> predicate, CancellationToken cancellationToken);

    Task<bool> Existing(Expression<Func<Entity, bool>> predicate, CancellationToken cancellationToken);

    Task<int> Count(Expression<Func<Entity, bool>> predicate, CancellationToken cancellationToken);

    Task<int> CountAll(CancellationToken cancellationToken);
}