namespace XTC.OpenEL.DDD.Infrastracture.DDD.EventBus;
public class AnyEventRecord : IEventRecord
{
    public string FullName { get; private set; }
    public IEventData Data { get; private set; }

    public AnyEventRecord(string _fullname, IEventData _eventData)
    {
        FullName = _fullname;
        Data = _eventData;
    }
}
