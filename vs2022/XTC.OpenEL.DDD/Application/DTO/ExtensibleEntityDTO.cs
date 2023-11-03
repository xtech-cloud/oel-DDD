using System;
using XTC.OpenEL.DDD.Infrastracture.DDD.ObjectExtending;

namespace XTC.OpenEL.DDD.Application.DTO;

[Serializable]
public abstract class ExtensibleEntityDTO<TKey> : ExtensibleObject, IEntityDTO<TKey>
{
    /// <summary>
    /// Id of the entity.
    /// </summary>
    public TKey Id { get; set; } = default!;

    protected ExtensibleEntityDTO()
    {

    }


    public override string ToString()
    {
        return $"[DTO: {GetType().Name}] Id = {Id}";
    }
}

[Serializable]
public abstract class ExtensibleEntityDTO : ExtensibleObject, IEntityDTO
{
    protected ExtensibleEntityDTO()
    {

    }

    public override string ToString()
    {
        return $"[DTO: {GetType().Name}]";
    }
}
