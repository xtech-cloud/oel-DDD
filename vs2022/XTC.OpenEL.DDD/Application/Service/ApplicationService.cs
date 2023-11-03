using Autofac;
using AutoMapper;
using XTC.OpenEL.DDD.Infrastracture.DDD.EventBus;
using XTC.OpenEL.DDD.Infrastracture.DDD.Linq;
using XTC.OpenEL.DDD.Infrastracture.DDD.Uid;
using XTC.OpenEL.DDD.Infrastracture.DependencyInjection;
using XTC.OpenEL.DDD.Infrastracture.Log;

namespace XTC.OpenEL.DDD.Application.Service;

public abstract class ApplicationService : IApplicationService
{
    protected IDependencyInjectionProvider dependencyInjectionProvider_ { get; set; }

    protected IGuidGenerator guidGenerator => dependencyInjectionProvider_.Container.Resolve<IGuidGenerator>();

    protected IAsyncQueryableExecuter asyncExecuter_ => dependencyInjectionProvider_.Container.Resolve<IAsyncQueryableExecuter>();
    protected ILog log_ => dependencyInjectionProvider_.Container.Resolve<ILog>();

    protected IMapper objectMapper_ => dependencyInjectionProvider_.Container.Resolve<IMapper>();

    protected IEventBus eventBus_ => dependencyInjectionProvider_.Container.Resolve<IEventBus>();
}
