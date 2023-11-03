namespace XTC.OpenEL.DDD.Application.DTO;

/// <summary>
/// This interface is defined to standardize to set "Total Count of Items" to a DTO.
/// </summary>
public interface IHasTotalCount
{
    /// <summary>
    /// Total count of Items.
    /// </summary>
    long TotalCount { get; set; }
}