namespace Eurus.Common.Domain;

public abstract class Aggregate<TKey, T> where T : IComparable<T>
{
    public TKey Id { get; set; } = default!;
    
    public abstract T AggregateId { get; }

    public int Version { get; protected set; }
}