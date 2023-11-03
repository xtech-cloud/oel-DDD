using System;
using System.Collections.Generic;

namespace XTC.OpenEL.DDD.Application.DTO;


/// <summary>
/// Implements <see cref="IPagedResult{T}"/>.
/// </summary>
/// <typeparam name="T">Type of the items in the <see cref="ListResultDTO{T}.Items"/> list</typeparam>
[Serializable]
public class PagedResultDTO<T> : ListResultDTO<T>, IPagedResult<T>
{
    /// <inheritdoc />
    public long TotalCount { get; set; } //TODO: Can be a long value..?

    /// <summary>
    /// Creates a new <see cref="PagedResultDTO{T}"/> object.
    /// </summary>
    public PagedResultDTO()
    {

    }

    /// <summary>
    /// Creates a new <see cref="PagedResultDTO{T}"/> object.
    /// </summary>
    /// <param name="totalCount">Total count of Items</param>
    /// <param name="items">List of items in current page</param>
    public PagedResultDTO(long totalCount, IReadOnlyList<T> items)
        : base(items)
    {
        TotalCount = totalCount;
    }
}

/// <summary>
/// Implements <see cref="IPagedResult{T}"/>.
/// </summary>
/// <typeparam name="T">Type of the items in the <see cref="ListResultDTO{T}.Items"/> list</typeparam>
[Serializable]
public class ExtensiblePagedResultDTO<T> : ExtensibleListResultDTO<T>, IPagedResult<T>
{
    /// <inheritdoc />
    public long TotalCount { get; set; } //TODO: Can be a long value..?

    /// <summary>
    /// Creates a new <see cref="PagedResultDTO{T}"/> object.
    /// </summary>
    public ExtensiblePagedResultDTO()
    {

    }

    /// <summary>
    /// Creates a new <see cref="PagedResultDTO{T}"/> object.
    /// </summary>
    /// <param name="totalCount">Total count of Items</param>
    /// <param name="items">List of items in current page</param>
    public ExtensiblePagedResultDTO(long totalCount, IReadOnlyList<T> items)
        : base(items)
    {
        TotalCount = totalCount;
    }
}
