using System;

namespace XTC.OpenEL.DDD.Domain.Entity;

[Serializable]
public abstract class AggregateRoot : BasicAggregateRoot
{
}

[Serializable]
public abstract class AggregateRoot<TKey> : BasicAggregateRoot<TKey>
{
    protected AggregateRoot(TKey id)
        : base(id)
    {
    }
}
