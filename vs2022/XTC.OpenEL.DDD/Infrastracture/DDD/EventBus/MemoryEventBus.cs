using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace XTC.OpenEL.DDD.Infrastracture.DDD.EventBus;

/// <summary>
/// 内存事件总线
/// </summary>
public class MemoryEventBus : IEventBus
{
    private ConcurrentDictionary<string, LinkedList<IEventHandler>> pool_ = new ConcurrentDictionary<string, LinkedList<IEventHandler>>();

    public async Task PublishAsync(IEventRecord _record)
    {
        var subscribers = getSubscribers(_record.FullName);
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
        Subscribe(typeof(T), new ActionEventHandler(_action));
    }

    public void Subscribe<T>(IEventHandler _handler) where T : IEventRecord
    {
        Subscribe(typeof(T), _handler);
    }

    public void Subscribe(Type _eventRecordType, Func<IEventRecord, Task> _action)
    {
        Subscribe(_eventRecordType, new ActionEventHandler(_action));
    }

    public void Subscribe(Type _eventRecordType, IEventHandler _handler)
    {
        if (!(_eventRecordType is IEventRecord))
            throw new DDDException("_eventRecordType is not IEventRecord");

        var subscribers = getSubscribers(_eventRecordType.FullName);
        subscribers.AddLast(_handler);
    }

    public void Unsubscribe<T>(Func<IEventRecord, Task> _action) where T : IEventRecord
    {
        Unsubscribe(typeof(T), _action);
    }

    public void Unsubscribe<T>(IEventHandler _handler) where T : IEventRecord
    {
        Unsubscribe(typeof(T), _handler);
    }

    public void Unsubscribe(Type _eventRecordType, Func<IEventRecord, Task> _action)
    {
        if (!(_eventRecordType is IEventRecord))
            throw new DDDException("_eventRecordType is not IEventRecord");

        var subscribers = getSubscribers(_eventRecordType.FullName);
        subscribers.RemoveAll((_item) => _item.Action == _action);
    }

    public void Unsubscribe(Type _eventRecordType, IEventHandler _handler)
    {
        Unsubscribe(_eventRecordType, _handler.Action);
    }

    public void UnsubscribeAll<T>() where T : IEventRecord
    {
        UnsubscribeAll(typeof(T));
    }

    public void UnsubscribeAll(Type _eventRecordType)
    {
        if (!(_eventRecordType is IEventRecord))
            throw new DDDException("_eventRecordType is not IEventRecord");

        var subscribers = getSubscribers(_eventRecordType.FullName);
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
