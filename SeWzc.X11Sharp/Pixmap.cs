using SeWzc.X11Sharp.Internal;

namespace SeWzc.X11Sharp;

public sealed class Pixmap
{
    internal readonly PixmapHandle Handle;

    internal Pixmap(PixmapHandle handle)
    {
        Handle = handle;
    }

    public static explicit operator IntPtr(Pixmap pixmap)
    {
        return pixmap.Handle.Value;
    }

    public static explicit operator Pixmap(IntPtr handle)
    {
        return new Pixmap(new PixmapHandle(handle));
    }
}
