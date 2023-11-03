using XTC.OpenEL.DDD.Infrastracture.DDD.EventBus;

namespace XTC.OpenEL.DDD.Domain.Event;

public class DomainEventRecord : IEventRecord
{
    public DomainEventRecord(IEventData _data)
    {
        Data = _data;
    }
    public string FullName
    {
        get
        {
            return this.GetType().FullName;
        }
    }

    public IEventData Data { get; protected set; }
}
