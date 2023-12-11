using System;
using System.Threading.Tasks;

namespace XTC.OpenEL.DDD.Infrastracture.EventBus;

public class ActionEventHandler : IEventHandler
{
    /// <summary>
    /// Function to handle the event.
    /// </summary>
    public virtual Func<IEventRecord, Task> Action { get; }

    /// <summary>
    /// Creates a new instance of <see cref="ActionEventHandler{TEvent}"/>.
    /// </summary>
    /// <param name="handler">Action to handle the event</param>
    public ActionEventHandler(Func<IEventRecord, Task> handler)
    {
        Action = handler;
    }

    /// <summary>
    /// Handles the event.
    /// </summary>
    /// <param name="eventData"></param>
    public virtual async Task HandleEventAsync(IEventRecord _record)
    {
        await Action(_record);
    }
}
