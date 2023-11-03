using System;

namespace XTC.OpenEL.DDD.Domain.Entity;


[Serializable]
public abstract class BasicAggregateRoot : Entity,
    IAggregateRoot
{
}

[Serializable]
public abstract class BasicAggregateRoot<TKey> : Entity<TKey>,
    IAggregateRoot<TKey>
{
    protected BasicAggregateRoot()
    {

    }

    protected BasicAggregateRoot(TKey id)
        : base(id)
    {

    }
}
