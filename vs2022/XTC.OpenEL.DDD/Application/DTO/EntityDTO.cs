using System;
using System.Collections.Generic;
using XTC.OpenEL.DDD.Infrastracture.DDD.ObjectExtending;

namespace XTC.OpenEL.DDD.Application.DTO;


/// <inheritdoc/>
[Serializable]
public abstract class EntityDTO : ExtensibleObject, IEntityDTO
{
    protected EntityDTO()
    {
    }

    /// <inheritdoc/>
    public override string ToString()
    {
        return $"[DTO: {GetType().Name}] Keys = {GetKeys().JoinAsString(", ")}";
    }

    public abstract object?[] GetKeys();
}

/// <inheritdoc cref="EntityDTO{TKey}" />
[Serializable]
public abstract class EntityDTO<TKey> : EntityDTO, IEntityDTO<TKey>
{
    /// <inheritdoc/>
    public virtual TKey Id { get; set; } = default!;

    protected EntityDTO()
    {

    }

    protected EntityDTO(TKey id)
    {
        Id = id;
    }

    public override object?[] GetKeys()
    {
        return new object?[] { Id };
    }

    /// <inheritdoc/>
    public override string ToString()
    {
        return $"[ENTITY: {GetType().Name}] Id = {Id}";
    }
}
