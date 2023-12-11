using System;

namespace XTC.OpenEL.DDD.Infrastracture.Data;


[Serializable]
public class ExtensibleObject : IHasExtraProperties
{
    public ExtraPropertyDictionary ExtraProperties { get; protected set; }

    public ExtensibleObject()
    {
        ExtraProperties = new ExtraPropertyDictionary();
    }
}
