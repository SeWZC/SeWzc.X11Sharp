using SeWzc.X11Sharp.Internal;

namespace SeWzc.X11Sharp;

public static partial class X11Lib
{
    /// <summary>
    /// 释放像素图。
    /// </summary>
    /// <param name="pixmap">要释放的像素图。</param>
    /// <seealso cref="X11DisplayPixmap.Free" />
    public static void FreePixmap(X11DisplayPixmap pixmap)
    {
        _ = XLib.XFreePixmap(pixmap.Display, pixmap);
    }
}
