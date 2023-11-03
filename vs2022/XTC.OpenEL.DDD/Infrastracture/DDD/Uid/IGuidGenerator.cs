
using System;

namespace XTC.OpenEL.DDD.Infrastracture.DDD.Uid;

/// <summary>
/// Used to generate Ids.
/// </summary>
public interface IGuidGenerator
{
    /// <summary>
    /// Creates a new <see cref="Guid"/>.
    /// </summary>
    Guid Create();
}
