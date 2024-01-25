using Autofac;
using XTC.OpenEL.DDD.Infrastracture.DependencyInjection;
using XTC.OpenEL.DDD.Infrastracture.Log;
using XTC.OpenEL.DDD.Infrastracture.Uid;

namespace XTC.OpenEL.DDD.Domain.Service;

public abstract class AbstractDomainService : IDomainService
{
    protected IDependencyInjectionProvider dependencyInjectionProvider_ { get; set; }
    protected IGuidGenerator guidGenerator_ => dependencyInjectionProvider_.Container.Resolve<IGuidGenerator>();
    protected ILog log_ => dependencyInjectionProvider_.Container.Resolve<ILog>();

    public AbstractDomainService(IDependencyInjectionProvider _dependencyInjectionProvider)
    {
        dependencyInjectionProvider_ = _dependencyInjectionProvider;
    }
}
