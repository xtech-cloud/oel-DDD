using System.Threading.Tasks;

namespace XTC.OpenEL.DDD.Application.Service;

public interface IDeleteAppService<in TKey> : IApplicationService
{
    Task DeleteAsync(TKey id);
}