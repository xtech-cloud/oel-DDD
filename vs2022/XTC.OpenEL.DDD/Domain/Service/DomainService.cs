using Autofac;
using XTC.OpenEL.DDD.Infrastracture.DDD.Uid;
using XTC.OpenEL.DDD.Infrastracture.DependencyInjection;
using XTC.OpenEL.DDD.Infrastracture.Log;

namespace XTC.OpenEL.DDD.Domain.Service;

public class DomainService : IDomainService
{
    protected IDependencyInjectionProvider dependencyInjectionProvider_ { get; set; }

    protected IGuidGenerator guidGenerator_ => dependencyInjectionProvider_.Container.Resolve<IGuidGenerator>();
    protected ILog log_ => dependencyInjectionProvider_.Container.Resolve<ILog>();
}
