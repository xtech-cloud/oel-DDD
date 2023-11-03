using System.Threading.Tasks;

namespace XTC.OpenEL.DDD.Application.Service;

public interface IUpdateAppService<TEntityDTO, in TKey>
: IUpdateAppService<TEntityDTO, TKey, TEntityDTO>
{

}

public interface IUpdateAppService<TGetOutputDTO, in TKey, in TUpdateInput>
: IApplicationService
{
    Task<TGetOutputDTO> UpdateAsync(TKey id, TUpdateInput input);
}