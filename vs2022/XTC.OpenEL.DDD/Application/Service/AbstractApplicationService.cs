using Autofac;
using AutoMapper;
using XTC.OpenEL.DDD.Infrastracture.DependencyInjection;
using XTC.OpenEL.DDD.Infrastracture.EventBus;
using XTC.OpenEL.DDD.Infrastracture.Linq;
using XTC.OpenEL.DDD.Infrastracture.Log;
using XTC.OpenEL.DDD.Infrastracture.Uid;

namespace XTC.OpenEL.DDD.Application.Service;

public abstract class AbstractApplicationService : IApplicationService
{
    protected IDependencyInjectionProvider dependencyInjectionProvider_ { get; set; }
    protected IGuidGenerator guidGenerator => dependencyInjectionProvider_.Container.Resolve<IGuidGenerator>();
    protected IAsyncQueryableExecuter asyncExecuter_ => dependencyInjectionProvider_.Container.Resolve<IAsyncQueryableExecuter>();
    protected ILog log_ => dependencyInjectionProvider_.Container.Resolve<ILog>();
    protected IMapper objectMapper_ => dependencyInjectionProvider_.Container.Resolve<IMapper>();
    protected IEventBus eventBus_ => dependencyInjectionProvider_.Container.Resolve<IEventBus>();

    public AbstractApplicationService(IDependencyInjectionProvider _dependencyInjectionprovider)
    {
        dependencyInjectionProvider_ = _dependencyInjectionprovider;
    }
}
