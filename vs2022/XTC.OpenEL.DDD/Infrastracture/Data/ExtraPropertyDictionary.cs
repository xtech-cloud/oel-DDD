using System;
using System.Collections.Generic;

namespace XTC.OpenEL.DDD.Infrastracture.Data;

[Serializable]
public class ExtraPropertyDictionary : Dictionary<string, object?>
{
    public ExtraPropertyDictionary()
    {

    }

    public ExtraPropertyDictionary(IDictionary<string, object?> dictionary)
        : base(dictionary)
    {
    }

    public T GetValue<T>(string _key, T _default)
    {
        object? value;
        if (!TryGetValue(_key, out value))
            return _default;

        if (null == value)
            return _default;

        if (!typeof(T).IsAssignableTo(value.GetType()) && !typeof(T).IsAssignableFrom(value.GetType()))
            return _default;
        return (T)value;
    }
}
