namespace RichillCapital.SharedKernel;

public interface IEntity
{
    IReadOnlyCollection<IDomainEvent> GetDomainEvents();
    void RaiseDomainEvent(IDomainEvent domainEvent);
    void ClearDomainEvents();
}

public abstract class Entity<TEntityId> :
    IEntity,
    IEquatable<Entity<TEntityId>>
    where TEntityId : class
{
    private readonly List<IDomainEvent> _domainEvents = [];

    protected Entity(TEntityId id) => Id = id;

    public TEntityId Id { get; private init; }

    public static bool operator ==(Entity<TEntityId>? a, Entity<TEntityId>? b) =>
        (a is null && b is null) ||
        (a is not null &&
            b is not null &&
            a.Equals(b));

    public static bool operator !=(Entity<TEntityId>? a, Entity<TEntityId>? b) => !(a == b);

    public IReadOnlyCollection<IDomainEvent> GetDomainEvents() => [.. _domainEvents];
    public void RaiseDomainEvent(IDomainEvent domainEvent) => _domainEvents.Add(domainEvent);
    public void ClearDomainEvents() => _domainEvents.Clear();

    public override bool Equals(object? obj) =>
        obj is not null &&
        (ReferenceEquals(this, obj) ||
        (obj.GetType() == GetType() &&
        obj is Entity<TEntityId> other &&
        Id == other.Id));

    public bool Equals(Entity<TEntityId>? other)
    {
        if (other is null)
        {
            return false;
        }

        return ReferenceEquals(this, other) || Id.Equals(other.Id);
    }

    public override int GetHashCode() => Id.GetHashCode() * 41;
}
