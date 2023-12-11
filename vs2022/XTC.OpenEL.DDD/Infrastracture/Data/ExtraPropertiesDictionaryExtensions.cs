using System.Collections.Generic;

namespace XTC.OpenEL.DDD.Infrastracture.Data;

public static class ExtraPropertiesDictionaryExtensions
{
    public static bool HasProperty(this IHasExtraProperties source, string name)
    {
        return source.ExtraProperties.ContainsKey(name);
    }

    public static object? GetProperty(this IHasExtraProperties source, string name, object? defaultValue = null)
    {
        return source.ExtraProperties.GetOrDefault(name)
               ?? defaultValue;
    }

    public static TSource SetProperty<TSource>(this TSource source, string name, object? value) where TSource : IHasExtraProperties
    {
        source.ExtraProperties[name] = value;

        return source;
    }

    public static TSource RemoveProperty<TSource>(this TSource source, string name)
        where TSource : IHasExtraProperties
    {
        source.ExtraProperties.Remove(name);
        return source;
    }
}
