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

    public static explicit operator IntPtr(GraphicsContext gc)
    {
        return gc.GC.Value;
    }

    public static explicit operator GraphicsContext(IntPtr handle)
    {
        return new GraphicsContext(new GCPtr(handle));
    }
}
