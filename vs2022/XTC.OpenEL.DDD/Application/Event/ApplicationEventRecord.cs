using XTC.OpenEL.DDD.Infrastracture.EventBus;

namespace XTC.OpenEL.DDD.Application.Event;

public abstract class ApplicationEventRecord : IEventRecord
{
    public ApplicationEventRecord(IEventData _data)
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
