using SeWzc.X11Sharp.Exceptions;
using SeWzc.X11Sharp.Internal;

namespace SeWzc.X11Sharp;

/// <summary>
/// X11DisplayPixmap 扩展方法。
/// </summary>
public static class X11DisplayPixmapExtensions
{
    /// <summary>
    /// 释放像素图。
    /// </summary>
    /// <param name="pixmap">要c操作的像素图。</param>
    public static void Free(this X11DisplayPixmap pixmap)
    {
        XLib.XFreePixmap(pixmap.Display, pixmap);
    }
}
