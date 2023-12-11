namespace XTC.OpenEL.DDD.Infrastracture.EventBus;

public interface IEventRecord
{
    string FullName { get; }

    IEventData Data { get; }
}
