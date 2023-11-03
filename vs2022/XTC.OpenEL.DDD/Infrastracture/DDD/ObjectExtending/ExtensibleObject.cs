using System;
using XTC.OpenEL.DDD.Infrastracture.DDD.Data;

namespace XTC.OpenEL.DDD.Infrastracture.DDD.ObjectExtending;


[Serializable]
public class ExtensibleObject : IHasExtraProperties
{
    public ExtraPropertyDictionary ExtraProperties { get; protected set; }

    public ExtensibleObject()
    {
        ExtraProperties = new ExtraPropertyDictionary();
    }
}
