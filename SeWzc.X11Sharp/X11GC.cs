using SeWzc.X11Sharp.Internal;

namespace SeWzc.X11Sharp;

/// <summary>
/// 图形上下文。
/// </summary>
public sealed class X11GC
{
    internal GCPtr Ptr { get; }

    private X11GC(GCPtr ptr)
    {
        Ptr = ptr;
    }

    private static WeakReferenceValueDictionary<nint, X11GC> Cache { get; } = new();

    public static explicit operator nint(X11GC gc)
    {
        return gc.Ptr.Value;
    }

    public static explicit operator X11GC?(nint handle)
    {
        return handle is 0 ? null : Cache.GetOrAdd(handle, static handle => new X11GC(new GCPtr(handle)));
    }
}
