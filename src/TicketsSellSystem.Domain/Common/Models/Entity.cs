namespace TicketsSellSystem.Domain.Common.Models;

public abstract class Entity<TId> : IEquatable<Entity<TId>>
    where TId : notnull
{
    protected Entity(TId id)
    {
        this.Id = id;
    }

    public TId Id { get; protected set; }

    public static bool operator ==(Entity<TId> left, Entity<TId> right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(Entity<TId> left, Entity<TId> right)
    {
        return !Equals(left, right);
    }

    public override bool Equals(object? obj)
    {
        return obj is Entity<TId> entity && this.Id.Equals(entity.Id);
    }

    public bool Equals(Entity<TId>? other)
    {
        return this.Equals((object?)other);
    }

    public override int GetHashCode()
    {
        return this.Id.GetHashCode();
    }
}