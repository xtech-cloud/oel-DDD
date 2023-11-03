using System;
using System.ComponentModel.DataAnnotations;

namespace XTC.OpenEL.DDD.Application.DTO;

/// <summary>
/// Simply implements <see cref="IPagedResultRequest"/>.
/// </summary>
[Serializable]
public class PagedResultRequestDTO : LimitedResultRequestDTO, IPagedResultRequest
{
    [Range(0, int.MaxValue)]
    public virtual int SkipCount { get; set; }
}

/// <summary>
/// Simply implements <see cref="IPagedResultRequest"/>.
/// </summary>
[Serializable]
public class ExtensiblePagedResultRequestDTO : ExtensibleLimitedResultRequestDTO, IPagedResultRequest
{
    [Range(0, int.MaxValue)]
    public virtual int SkipCount { get; set; }
}
