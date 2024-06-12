using SeWzc.X11Sharp.Internal;

namespace SeWzc.X11Sharp;

/// <summary>
/// 图形上下文。
/// </summary>
public sealed class X11GC
{
    internal readonly GCPtr GC;

    internal X11GC(GCPtr gc)
    {
        GC = gc;
    }

    private static WeakReferenceValueDictionary<nint, X11GC> Cache { get; } = new();

    public static explicit operator nint(X11GC gc)
    {
        return gc.GC.Value;
    }

    public static explicit operator X11GC(nint handle)
    {
        return Cache.GetOrAdd(handle, static handle => new X11GC(new GCPtr(handle)));
    }
}
