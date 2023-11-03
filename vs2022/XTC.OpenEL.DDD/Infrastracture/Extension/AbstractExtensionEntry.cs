using System;

namespace XTC.OpenEL.DDD.Infrastracture.Extension;

public abstract class AbstractExtensionEntry<T> : IExtensionEntry
{
    /// <summary>
    /// 配置
    /// </summary>
    /// <param name="_builder">构建器</param>
    public abstract void Configure(IExtensionBuilder _builder);

    /// <summary>
    /// 启动
    /// </summary>
    /// <param name="_context">扩展上下文</param>
    /// <param name="_progressChanged">进度更新回调，参数为(范围为[0.0, 1.0]的进度，信息)，</param>
    /// <returns></returns>
    public abstract T BootAsync(ExtensionContext _context, Action<float, string> _progressChanged);

    /// <summary>
    /// 运行
    /// </summary>
    /// <param name="_context">扩展上下文</param>
    public abstract void Run(ExtensionContext _context);

    /// <summary>
    /// 停止
    /// </summary>
    /// <param name="_context">扩展上下文</param>
    public abstract void Halt(ExtensionContext _context);
}
