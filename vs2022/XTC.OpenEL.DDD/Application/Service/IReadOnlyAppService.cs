using System.Threading.Tasks;
using XTC.OpenEL.DDD.Application.DTO;

namespace XTC.OpenEL.DDD.Application.Service;

public interface IReadOnlyAppService<TEntityDTO, in TKey>
: IReadOnlyAppService<TEntityDTO, TEntityDTO, TKey, PagedAndSortedResultRequestDTO>
{

}

public interface IReadOnlyAppService<TEntityDTO, in TKey, in TGetListInput>
: IReadOnlyAppService<TEntityDTO, TEntityDTO, TKey, TGetListInput>
{

}

public interface IReadOnlyAppService<TGetOutputDTO, TGetListOutputDTO, in TKey, in TGetListInput>
: IApplicationService
{
    Task<TGetOutputDTO> GetAsync(TKey id);

    Task<PagedResultDTO<TGetListOutputDTO>> GetListAsync(TGetListInput input);
}
