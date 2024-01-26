using XTC.OpenEL.DDD.Infrastracture.EventBus;

namespace XTC.OpenEL.DDD.Domain.Event;

public abstract class DomainEventRecord : IEventRecord
{
    public DomainEventRecord(IEventData _data)
    {
        Data = _data;
    }

    public string ID
    {
        get
        {
            return this.GetType().FullName;
        }
    }

    public IEventData Data { get; protected set; }
}
