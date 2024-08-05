using Autofac;
using XTC.OpenEL.DDD.Infrastracture.DependencyInjection;
using XTC.OpenEL.DDD.Infrastracture.EventBus;
using XTC.OpenEL.DDD.Infrastracture.Log;

namespace XTC.OpenEL.DDD.UserInterface.Facade
{
    public abstract class AbstractFacade : IFacade
    {
        protected IDependencyInjectionProvider? dependencyInjectionProvider_ { get; set; }
        protected ILog? log_ => dependencyInjectionProvider_?.Container.Resolve<ILog>();
        protected IEventBus? eventBus_ => dependencyInjectionProvider_?.Container.Resolve<IEventBus>();
    }
}
