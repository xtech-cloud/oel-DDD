using Autofac;
using XTC.OpenEL.DDD.Infrastracture.Data;

namespace XTC.OpenEL.DDD.Infrastracture.Extension;

public class ExtensionContext : ExtensibleObject
{
    /// <summary>
    /// 依赖注入容器
    /// </summary>
    public IContainer DIC { get; private set; }


    public ExtensionContext(IContainer _container)
        : base()
    {
        DIC = _container;
    }
}
