using System;

namespace XTC.OpenEL.DDD.Domain.Entity;

/// <summary>
/// A standard interface to add DeletionTime property.
/// </summary>
public interface IHasDeletionTime
{
    /// <summary>
    /// Creation time.
    /// </summary>
    DateTime DeletionTime { get; }
}
