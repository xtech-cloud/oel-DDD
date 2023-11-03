using System;
using System.Collections.Generic;

namespace XTC.OpenEL.DDD.Infrastracture.DDD.Data;

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
}
