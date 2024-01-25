using Autofac;
using XTC.OpenEL.DDD.Infrastracture.DependencyInjection;
using XTC.OpenEL.DDD.Infrastracture.Log;

namespace XTC.OpenEL.DDD.Domain.Repository;

public abstract class AbstractRepository: IRepository
{
    protected IDependencyInjectionProvider dependencyInjectionProvider_ { get; set; }
    protected ILog log_ => dependencyInjectionProvider_.Container.Resolve<ILog>();

    public AbstractRepository(IDependencyInjectionProvider _dependencyInjectionprovider)
    {
        dependencyInjectionProvider_ = _dependencyInjectionprovider;
    }
}
