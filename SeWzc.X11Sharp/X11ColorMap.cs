using SeWzc.X11Sharp.Internal;

namespace SeWzc.X11Sharp;

public sealed class X11ColorMap
{
    internal ColormapHandle Handle { get; }

    private X11ColorMap(ColormapHandle handle)
    {
        Handle = handle;
    }

    private static WeakReferenceValueDictionary<nint, X11ColorMap> Cache { get; } = new();

    public static explicit operator nint(X11ColorMap colormap)
    {
        return colormap.Handle.Value;
    }

    public static explicit operator X11ColorMap(nint handle)
    {
        return Cache.GetOrAdd(handle, static handle => new X11ColorMap(new ColormapHandle(handle)));
    }
}
