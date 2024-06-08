using SeWzc.X11Sharp.Internal;

namespace SeWzc.X11Sharp;

public class ColorMap
{
    internal readonly ColormapHandle Handle;

    internal ColorMap(ColormapHandle handle)
    {
        Handle = handle;
    }

    public static explicit operator IntPtr(ColorMap colormap)
    {
        return colormap.Handle.Handle;
    }

    public static explicit operator ColorMap(IntPtr handle)
    {
        return new ColorMap(new ColormapHandle(handle));
    }
}