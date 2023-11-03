using System.Threading.Tasks;

namespace XTC.OpenEL.DDD.Application.Service;

public interface ICreateAppService<TEntityDTO>
: ICreateAppService<TEntityDTO, TEntityDTO>
{

}

public interface ICreateAppService<TGetOutputDTO, in TCreateInput>
: IApplicationService
{
    Task<TGetOutputDTO> CreateAsync(TCreateInput input);
}
