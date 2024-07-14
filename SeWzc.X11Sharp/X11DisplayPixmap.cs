using SeWzc.X11Sharp.Internal;

namespace SeWzc.X11Sharp;

/// <summary>
/// Display 和 Pixmap 的组合。
/// </summary>
public readonly record struct X11DisplayPixmap(X11Display Display, X11Pixmap Pixmap)
{
    /// <summary>
    /// 释放像素图。
    /// </summary>
    public void Free()
    {
        _ = XLib.XFreePixmap(Display, Pixmap);
    }

    #region 运算符重载

    // 强制转换就不用文档了
#pragma warning disable CS1591
    public static implicit operator X11Pixmap(X11DisplayPixmap displayPixmap)
    {
        return displayPixmap.Pixmap;
    }

    /// <summary>
    /// 强制转换为 X11DisplayDrawable。
    /// </summary>
    public static implicit operator X11DisplayDrawable(X11DisplayPixmap value)
    {
        return new X11DisplayDrawable(value.Display, value.Pixmap);
    }

    /// <summary>
    /// 从 X11DisplayDrawable 强制转换为 X11DisplayPixmap。需要确保 X11DisplayDrawable.Drawable 是一个像素图。
    /// </summary>
    public static explicit operator X11DisplayPixmap(X11DisplayDrawable value)
    {
        return new X11Pixmap(value.Drawable.Id).WithDisplay(value.Display);
    }
#pragma warning restore CS1591

    #endregion
}
