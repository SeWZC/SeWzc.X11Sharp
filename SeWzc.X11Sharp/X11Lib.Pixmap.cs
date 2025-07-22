using SeWzc.X11Sharp.Internal;
using SeWzc.X11Sharp.Structs;

namespace SeWzc.X11Sharp;

public static partial class X11Lib
{
    /// <summary>
    /// 释放像素图。
    /// </summary>
    /// <param name="pixmap">要释放的像素图。</param>
    /// <seealso cref="X11DisplayPixmapExtensions.Free" />
    public static void FreePixmap(X11DisplayPixmap pixmap)
    {
        _ = XLib.XFreePixmap(pixmap.Display, pixmap);
    }

    /// <summary>
    /// 从像素图创建光标。
    /// </summary>
    /// <param name="source">源像素图。</param>
    /// <param name="mask">掩码像素图。</param>
    /// <param name="foreground">前景色。</param>
    /// <param name="background">背景色。</param>
    /// <param name="x">指定指针在像素图的 x 坐标。</param>
    /// <param name="y">指定指针在像素图的 y 坐标。</param>
    /// <returns></returns>
    public static X11DisplayCursor CreatePixmapCursor(this X11DisplayPixmap source, X11Pixmap mask, XColor foreground, XColor background,
        uint x, uint y)
    {
        return XLib.XCreatePixmapCursor(source.Display, source, mask, foreground, background, x, y).WithDisplay(source.Display);
    }
}
