namespace ExpenseTracking.Domain.Entities;

public interface IEntity;

public abstract class BaseEntity<T> : object, IEntity
{
    public T Id { get; set; }

}

public abstract class BaseEntity : BaseEntity<int>;

public abstract class BaseObject : BaseEntity
{
    public Guid KeyGuid { get; set; } = Guid.NewGuid();

    public Guid Creator { get; set; }

    public DateTime CreationDate { get; set; } = DateTime.UtcNow;

    public Guid Modifier { get; set; }

    public DateTime ModifiedDate { get; set; } = DateTime.UtcNow;

    public bool IsBusy { get; set; } = false;

    public bool IsLoock { get; set; } = false;

    public DateTime ExpireLockDate { get; set; } = DateTime.MinValue;

    public bool IsActive { get; set; } = true;

    public bool IsDeleted { get; set; } = false;

}