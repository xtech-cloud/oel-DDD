using System.Runtime.Serialization;

namespace XTC.OpenEL.DDD.Infrastracture.Error;

/// <summary>
/// Base exception type for those are thrown by Abp system for Abp specific exceptions.
/// </summary>
public class DDDException : System.Exception
{
    public DDDException()
    {

    }

    public DDDException(string? message)
        : base(message)
    {

    }

    public DDDException(string? message, System.Exception? innerException)
        : base(message, innerException)
    {

    }

    public DDDException(SerializationInfo serializationInfo, StreamingContext context)
        : base(serializationInfo, context)
    {

    }
}
