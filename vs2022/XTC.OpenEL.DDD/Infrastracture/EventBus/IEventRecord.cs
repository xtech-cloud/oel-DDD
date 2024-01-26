namespace XTC.OpenEL.DDD.Infrastracture.EventBus;

public interface IEventRecord
{
    IEventData Data { get; }
}
