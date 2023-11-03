using System;
using System.Collections.Generic;
using XTC.OpenEL.DDD.Infrastracture.DDD.ObjectExtending;

namespace XTC.OpenEL.DDD.Application.DTO;

[Serializable]
public class ListResultDTO<T> : IListResult<T>
{
    /// <inheritdoc />
    public IReadOnlyList<T> Items
    {
        get { return _items ?? (_items = new List<T>()); }
        set { _items = value; }
    }
    private IReadOnlyList<T>? _items;

    /// <summary>
    /// Creates a new <see cref="ListResultDto{T}"/> object.
    /// </summary>
    public ListResultDTO()
    {

    }

    /// <summary>
    /// Creates a new <see cref="ListResultDto{T}"/> object.
    /// </summary>
    /// <param name="items">List of items</param>
    public ListResultDTO(IReadOnlyList<T> items)
    {
        Items = items;
    }
}

[Serializable]
public class ExtensibleListResultDTO<T> : ExtensibleObject, IListResult<T>
{
    /// <inheritdoc />
    public IReadOnlyList<T> Items
    {
        get { return _items ?? (_items = new List<T>()); }
        set { _items = value; }
    }
    private IReadOnlyList<T>? _items;

    /// <summary>
    /// Creates a new <see cref="ListResultDto{T}"/> object.
    /// </summary>
    public ExtensibleListResultDTO()
    {

    }

    /// <summary>
    /// Creates a new <see cref="ListResultDto{T}"/> object.
    /// </summary>
    /// <param name="items">List of items</param>
    public ExtensibleListResultDTO(IReadOnlyList<T> items)
    {
        Items = items;
    }
}