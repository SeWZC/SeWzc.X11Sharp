using SeWzc.X11Sharp.Exceptions;
using SeWzc.X11Sharp.Internal;
using SeWzc.X11Sharp.Structs;

namespace SeWzc.X11Sharp;

public static partial class X11Lib
{
    /// <summary>
    /// 修改光标的颜色。
    /// </summary>
    /// <param name="cursor">要操作的光标。</param>
    /// <param name="foreground">前景色。</param>
    /// <param name="background">背景色。</param>
    public static void RecolorCursor(this X11DisplayCursor cursor, XColor foreground, XColor background)
    {
        XLib.XRecolorCursor(cursor.Display, cursor, foreground, background);
    }

    /// <summary>
    /// 释放光标资源。
    /// </summary>
    /// <param name="cursor">要操作的光标。</param>
    public static void FreeCursor(this X11DisplayCursor cursor)
    {
        XLib.XFreeCursor(cursor.Display, cursor);
    }
}
