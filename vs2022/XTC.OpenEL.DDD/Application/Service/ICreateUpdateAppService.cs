namespace XTC.OpenEL.DDD.Application.Service;

public interface ICreateUpdateAppService<TEntityDTO, in TKey>
: ICreateUpdateAppService<TEntityDTO, TKey, TEntityDTO, TEntityDTO>
{

}

public interface ICreateUpdateAppService<TEntityDTO, in TKey, in TCreateUpdateInput>
: ICreateUpdateAppService<TEntityDTO, TKey, TCreateUpdateInput, TCreateUpdateInput>
{

}

public interface ICreateUpdateAppService<TGetOutputDTO, in TKey, in TCreateUpdateInput, in TUpdateInput>
: ICreateAppService<TGetOutputDTO, TCreateUpdateInput>,
    IUpdateAppService<TGetOutputDTO, TKey, TUpdateInput>
{

}
