using System;
using System.Threading.Tasks;

namespace XTC.OpenEL.DDD.Infrastracture.EventBus;

/// <summary>
/// 消息型的内存事件总线
/// </summary>
public class MessageMemoryEventBus : MemoryEventBus
{
    public async Task PublishDynamicAsync(string _subject, IEventRecord _record)
    {
        var subscribers = getSubscribers(_subject);
        foreach (var handler in subscribers)
        {
            if (null == handler)
                continue;
            await handler.Action.Invoke(_record);
        }
        await Task.CompletedTask;
    }

    public void SubscribeDynamic(string _subject, Func<IEventRecord, Task> _action)
    {
        subscribe(_subject,_action);
    }

    public void UnsubscribeDynamic(string _subject, Func<IEventRecord, Task> _action)
    {
        unsubscribe(_subject, _action);
    }

    public void UnsubscribeDynamicAll(string _subject)
    {
        unsubscribeAll(_subject);
    }
}
