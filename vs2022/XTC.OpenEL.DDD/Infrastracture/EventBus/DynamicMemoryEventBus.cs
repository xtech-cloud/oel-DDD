using System;
using System.Threading.Tasks;

namespace XTC.OpenEL.DDD.Infrastracture.EventBus;

/// <summary>
/// 动态事件的内存事件总线
/// </summary>
public class DynamicMemoryEventBus : MemoryEventBus
{
    public async Task PublishDynamicAsync(DynamicEventRecord _record)
    {
        var subscribers = getSubscribers(_record.ID);
        foreach (var handler in subscribers)
        {
            if (null == handler)
                continue;
            await handler.Action.Invoke(_record);
        }
        await Task.CompletedTask;
    }
}
