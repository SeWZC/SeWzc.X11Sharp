using SeWzc.X11Sharp.Internal;
using SeWzc.X11Sharp.Xid;

namespace SeWzc.X11Sharp;

/// <summary>
/// 图形上下文。
/// </summary>
public sealed class X11GC
{
    private X11GC(GCPtr ptr)
    {
        Ptr = ptr;
    }

    internal GCPtr Ptr { get; }

    private static WeakReferenceValueDictionary<nint, X11GC> Cache { get; } = new();

    /// <summary>
    /// GContext 资源。
    /// </summary>
    public X11GContext GContext => XLib.XGContextFromGC(Ptr);

    /// <summary>
    /// 与 Display 进行组合，以便进行操作。
    /// </summary>
    /// <param name="display">与 X 服务器的连接。</param>
    /// <returns>Display 与 GC 的组合。</returns>
    public X11DisplayGC WithDisplay(X11Display display)
    {
        return new X11DisplayGC(display, this);
    }

    #region 运算符重载

    // 强制转换不需要文档
#pragma warning disable CS1591

    public static explicit operator nint(X11GC gc)
    {
        return gc.Ptr.Value;
    }

    public static explicit operator X11GC?(nint handle)
    {
        return handle is 0 ? null : Cache.GetOrAdd(handle, static handle => new X11GC(new GCPtr(handle)));
    }

#pragma warning restore CS1591

    #endregion
}
