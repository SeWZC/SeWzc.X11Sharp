using SeWzc.X11Sharp.Internal;

namespace SeWzc.X11Sharp;

/// <summary>
/// 图形上下文。
/// </summary>
public sealed class GraphicsContext
{
    internal readonly GCPtr GC;

    internal GraphicsContext(GCPtr gc)
    {
        GC = gc;
    }

    private static WeakReferenceValueDictionary<nint, GraphicsContext> Cache { get; } = new();

    public static explicit operator nint(GraphicsContext gc)
    {
        return gc.GC.Value;
    }

    public static explicit operator GraphicsContext(nint handle)
    {
        return Cache.GetOrAdd(handle, static handle => new GraphicsContext(new GCPtr(handle)));
    }
}
