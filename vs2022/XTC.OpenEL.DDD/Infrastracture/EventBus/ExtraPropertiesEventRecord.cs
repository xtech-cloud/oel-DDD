namespace XTC.OpenEL.DDD.Infrastracture.EventBus;

public class ExtraPropertiesEventRecord : IEventRecord
{
    public IEventData Data { get; private set; }

    public ExtraPropertiesEventRecord(ExtraPropertiesEventData _data)
    {
        Data = _data;
    }
}
