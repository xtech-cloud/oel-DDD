namespace XTC.OpenEL.DDD.Infrastracture.DDD.EventBus;

public interface IEventRecord
{
    string FullName { get; }

    IEventData Data { get; }
}
