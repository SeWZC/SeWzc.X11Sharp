using SeWzc.X11Sharp.Internal;
using SeWzc.X11Sharp.Structs;

namespace SeWzc.X11Sharp;

/// <summary>
/// Display 和 Cursor 的组合。
/// </summary>
public readonly record struct X11DisplayCursor(X11Display Display, X11Cursor Cursor)
{
    /// <summary>
    /// 修改光标的颜色。
    /// </summary>
    /// <param name="foreground">前景色。</param>
    /// <param name="background">背景色。</param>
    public void RecolorCursor(XColor foreground, XColor background)
    {
        XLib.XRecolorCursor(Display, Cursor, foreground, background);
    }

    /// <summary>
    /// 释放光标资源。
    /// </summary>
    public void FreeCursor()
    {
        XLib.XFreeCursor(Display, Cursor);
    }

    #region 运算符重载

    // 强制转换就不用文档了
#pragma warning disable CS1591
    public static implicit operator X11Cursor(X11DisplayCursor displayCursor)
    {
        return displayCursor.Cursor;
    }
#pragma warning restore CS1591

    #endregion
}
