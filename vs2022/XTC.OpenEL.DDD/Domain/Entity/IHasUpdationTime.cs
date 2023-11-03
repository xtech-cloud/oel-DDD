using System;

namespace XTC.OpenEL.DDD.Domain.Entity;

/// <summary>
/// A standard interface to add UpdationTime property.
/// </summary>
public interface IHasUpdationTime
{
    /// <summary>
    /// Creation time.
    /// </summary>
    DateTime UpdationTime { get; }
}
