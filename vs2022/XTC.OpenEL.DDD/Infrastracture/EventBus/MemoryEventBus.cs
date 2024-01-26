using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace XTC.OpenEL.DDD.Infrastracture.EventBus;

/// <summary>
/// 内存事件总线
/// </summary>
public class MemoryEventBus : IEventBus
{
    private ConcurrentDictionary<string, LinkedList<IEventHandler>> pool_ = new ConcurrentDictionary<string, LinkedList<IEventHandler>>();

    public async Task PublishAsync(IEventRecord _record)
    {
        var subscribers = getSubscribers(_record.GetType().FullName);
        foreach (var handler in subscribers)
        {
            if (null == handler)
                continue;
            await handler.Action.Invoke(_record);
        }
        await Task.CompletedTask;
    }

    public void Subscribe<T>(Func<IEventRecord, Task> _action) where T : IEventRecord
    {
        subscribe(typeof(T).FullName, new ActionEventHandler(_action));
    }

    public void Subscribe<T>(IEventHandler _handler) where T : IEventRecord
    {
        subscribe(typeof(T).FullName, _handler);
    }


    public void Unsubscribe<T>(Func<IEventRecord, Task> _action) where T : IEventRecord
    {
        unsubscribe(typeof(T).FullName, _action);
    }

    public void Unsubscribe<T>(IEventHandler _handler) where T : IEventRecord
    {
        unsubscribe(typeof(T).FullName, _handler.Action);
    }

    public void UnsubscribeAll<T>() where T : IEventRecord
    {
        unsubscribeAll(typeof(T).FullName);
    }

    private void subscribe(string _subject, IEventHandler _handler)
    {
        var subscribers = getSubscribers(_subject);
        subscribers.AddLast(_handler);
    }

    private void unsubscribe(string _subject, Func<IEventRecord, Task> _action)
    {
        var subscribers = getSubscribers(_subject);
        subscribers.RemoveAll((_item) => _item.Action == _action);
    }

    private void unsubscribeAll(string _subject)
    {
        var subscribers = getSubscribers(_subject);
        subscribers.Clear();
    }

    private LinkedList<IEventHandler> getSubscribers(string _subject)
    {
        LinkedList<IEventHandler> handlers;
        if (!pool_.TryGetValue(_subject, out handlers))
        {
            handlers = new LinkedList<IEventHandler>();
            pool_[_subject] = handlers;
        }
        return handlers;
    }
}
