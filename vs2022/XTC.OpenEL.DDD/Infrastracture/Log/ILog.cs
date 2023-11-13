using System;

namespace XTC.OpenEL.DDD.Infrastracture.Log;

public interface ILog
{
    void Trace(object _message);
    void Debug(object _message);
    void Info(object _message);
    void Warning(object _message);
    void Error(object _message);
    void Exception(Exception _ex);
    void Fatal(object _message);
}
