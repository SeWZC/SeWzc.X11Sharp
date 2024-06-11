using SeWzc.X11Sharp.Internal;

namespace SeWzc.X11Sharp;

public sealed class Pixmap
{
    internal readonly PixmapHandle Handle;

    internal Pixmap(PixmapHandle handle)
    {
        Handle = handle;
    }

    private static WeakReferenceValueDictionary<nint, Pixmap> Cache { get; } = new();

    public static explicit operator nint(Pixmap pixmap)
    {
        return pixmap.Handle.Value;
    }

    public static explicit operator Pixmap(nint handle)
    {
        return Cache.GetOrAdd(handle, static handle => new Pixmap(new PixmapHandle(handle)));
    }
}
