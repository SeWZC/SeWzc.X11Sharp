using SeWzc.X11Sharp.Internal;

namespace SeWzc.X11Sharp;

public sealed class X11Pixmap : X11Drawable
{
    private X11Pixmap(PixmapHandle handle) : base(handle)
    {
    }

    internal new PixmapHandle Handle => (PixmapHandle)base.Handle;

    internal DrawableHandle DrawableHandle => base.Handle;

    private static WeakReferenceValueDictionary<nint, X11Pixmap> Cache { get; } = new();

    public static explicit operator nint(X11Pixmap pixmap)
    {
        return pixmap.Handle.Value;
    }

    public static explicit operator X11Pixmap(nint handle)
    {
        return Cache.GetOrAdd(handle, static handle => new X11Pixmap(new PixmapHandle(handle)));
    }
}
