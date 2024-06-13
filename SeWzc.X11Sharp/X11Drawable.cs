using SeWzc.X11Sharp.Internal;

namespace SeWzc.X11Sharp;

public class X11Drawable
{
    private protected X11Drawable(DrawableHandle handle)
    {
        Handle = handle;
    }

    internal DrawableHandle Handle { get; }

    private static WeakReferenceValueDictionary<nint, X11Drawable> Cache { get; } = new();

    public static explicit operator nint(X11Drawable Drawable)
    {
        return Drawable.Handle.Value;
    }

    public static explicit operator X11Drawable(nint handle)
    {
        return Cache.GetOrAdd(handle, static handle => new X11Drawable(new DrawableHandle(handle)));
    }
}
