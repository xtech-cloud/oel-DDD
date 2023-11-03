using Autofac;

namespace XTC.OpenEL.DDD.Infrastracture.DependencyInjection;

public interface IDependencyInjectionProvider
{
    IContainer Container { get; }
}
