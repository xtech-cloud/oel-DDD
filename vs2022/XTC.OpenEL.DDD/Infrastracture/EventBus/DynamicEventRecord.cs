namespace XTC.OpenEL.DDD.Infrastracture.EventBus;
public class DynamicEventRecord : IEventRecord
{
    public string ID { get; private set; }
    public IEventData Data { get; private set; }

    public DynamicEventRecord(string _id, IEventData _eventData)
    {
        ID = _id;
        Data = _eventData;
    }
}
