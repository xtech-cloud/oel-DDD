using Autofac;

namespace XTC.OpenEL.DDD.Infrastracture.Extension;

public class ExtensionContext
{
    /// <summary>
    /// 依赖注入容器
    /// </summary>
    public IContainer DIC { get; private set; }

    public ExtensionContext(IContainer _container)
    {
        DIC = _container;
    }
}
