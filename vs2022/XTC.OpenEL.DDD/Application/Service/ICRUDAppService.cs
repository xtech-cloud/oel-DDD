
using XTC.OpenEL.DDD.Application.DTO;

namespace XTC.OpenEL.DDD.Application.Service;

public interface ICRUDAppService<TEntityDTO, in TKey>
    : ICRUDAppService<TEntityDTO, TKey, PagedAndSortedResultRequestDTO>
{

}

public interface ICRUDAppService<TEntityDTO, in TKey, in TGetListInput>
    : ICRUDAppService<TEntityDTO, TKey, TGetListInput, TEntityDTO>
{

}

public interface ICRUDAppService<TEntityDTO, in TKey, in TGetListInput, in TCreateInput>
    : ICRUDAppService<TEntityDTO, TKey, TGetListInput, TCreateInput, TCreateInput>
{

}

public interface ICRUDAppService<TEntityDTO, in TKey, in TGetListInput, in TCreateInput, in TUpdateInput>
    : ICRUDAppService<TEntityDTO, TEntityDTO, TKey, TGetListInput, TCreateInput, TUpdateInput>
{

}

public interface ICRUDAppService<TGetOutputDTO, TGetListOutputDTO, in TKey, in TGetListInput, in TCreateInput, in TUpdateInput>
    : IReadOnlyAppService<TGetOutputDTO, TGetListOutputDTO, TKey, TGetListInput>,
        ICreateUpdateAppService<TGetOutputDTO, TKey, TCreateInput, TUpdateInput>,
        IDeleteAppService<TKey>
{

}
