using XTC.OpenEL.DDD.Infrastracture.DDD.EventBus;

namespace XTC.OpenEL.DDD.Application.Event;

public class ApplicationEventRecord : IEventRecord
{
    public ApplicationEventRecord(IEventData _data)
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
