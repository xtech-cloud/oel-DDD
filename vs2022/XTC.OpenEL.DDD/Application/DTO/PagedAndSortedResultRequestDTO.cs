using System;

namespace XTC.OpenEL.DDD.Application.DTO;

/// <summary>
/// Simply implements <see cref="IPagedAndSortedResultRequest"/>.
/// </summary>
[Serializable]
public class PagedAndSortedResultRequestDTO : PagedResultRequestDTO, IPagedAndSortedResultRequest
{
    public virtual string? Sorting { get; set; }
}

/// <summary>
/// Simply implements <see cref="IPagedAndSortedResultRequest"/>.
/// </summary>
[Serializable]
public class ExtensiblePagedAndSortedResultRequestDTO : ExtensiblePagedResultRequestDTO, IPagedAndSortedResultRequest
{
    public virtual string? Sorting { get; set; }
}
