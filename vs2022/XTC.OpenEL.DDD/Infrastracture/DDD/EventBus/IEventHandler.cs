using System;
using System.Threading.Tasks;

namespace XTC.OpenEL.DDD.Infrastracture.DDD.EventBus;

/// <summary>
/// Indirect base interface for all event handlers.
/// </summary>
public interface IEventHandler
{
    /// <summary>
    /// Function to handle the event.
    /// </summary>
    Func<IEventRecord, Task> Action { get; }
}
