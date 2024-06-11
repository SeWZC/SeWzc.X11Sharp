using SeWzc.X11Sharp.Internal;

namespace SeWzc.X11Sharp;

public sealed class ColorMap
{
    internal readonly ColormapHandle Handle;

    internal ColorMap(ColormapHandle handle)
    {
        Handle = handle;
    }

    private static WeakReferenceValueDictionary<nint, ColorMap> Cache { get; } = new();

    public static explicit operator nint(ColorMap colormap)
    {
        return colormap.Handle.Value;
    }

    public static explicit operator ColorMap(nint handle)
    {
        return Cache.GetOrAdd(handle, static handle => new ColorMap(new ColormapHandle(handle)));
    }
}
