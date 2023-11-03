using System;
using XTC.OpenEL.DDD.Infrastracture.DDD.Data;
using XTC.OpenEL.DDD.Infrastracture.DDD.ObjectExtending;

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
