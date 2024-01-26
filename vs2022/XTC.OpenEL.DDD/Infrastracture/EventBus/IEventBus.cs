using System;
using System.Threading.Tasks;

namespace XTC.OpenEL.DDD.Infrastracture.EventBus;

public interface Factory<T>
{

}

/// <summary>
/// 事件总线
/// </summary>
/// <remarks>
/// 使用IEventRecord.FullName作为消息，IEventRecord.Data作为数据
/// FullName相同视为同一种事件
/// </remarks>
public interface IEventBus
{
    Task PublishAsync(IEventRecord _record);

    void Subscribe<T>(Func<IEventRecord, Task> _action) where T : IEventRecord;

    void Subscribe<T>(IEventHandler _handler) where T : IEventRecord;

    void Unsubscribe<T>(Func<IEventRecord, Task> _action) where T : IEventRecord;

    void Unsubscribe<T>(IEventHandler _handler) where T : IEventRecord;

    void UnsubscribeAll<T>() where T : IEventRecord;
}
